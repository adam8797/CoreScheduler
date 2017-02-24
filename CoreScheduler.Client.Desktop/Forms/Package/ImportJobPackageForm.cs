using System;
using System.Data.Entity;
using System.Windows.Forms;
using CoreScheduler.Client.Desktop.Base;
using CoreScheduler.Client.Desktop.Serializer;
using CoreScheduler.Client.Desktop.Utilities;
using CoreScheduler.Client.Desktop.Utilities.Tree;
using CoreScheduler.Server;
using CoreScheduler.Server.Options;
using CoreScheduler.Server.Utilities;
using Quartz;

namespace CoreScheduler.Client.Desktop.Forms.Package
{
    public partial class ImportJobPackageForm : FormBase
    {
        private readonly string _bundlePath;
        private JobDependencyBundle _bundle;

        public ImportJobPackageForm(string package)
        {
            InitializeComponent();

            if (package == null)
            {
                if (openFileDialog.ShowDialog() != DialogResult.OK)
                    Close();

                package = openFileDialog.FileName;
            }

            lblFilePath.Text = _bundlePath = package;
        }

        protected override void OnLoad(EventArgs e)
        {
            string secret = null;
            
            if (JobSerializer.IsEncrypted(_bundlePath))
            {
                while (true)
                {
                    if (TextPrompt.PromptPassword("The package has encrypted elements. Enter the secret to unlock.", "Secret required", out secret) != DialogResult.OK)
                    {
                        Close();
                        return;
                    }

                    if (secret.Length >= 6 && JobSerializer.CheckPassword(_bundlePath, secret))
                        break;

                    MessageBox.Show("Password Incorrect", "Password Incorrect", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
            _bundle = JobSerializer.Read(_bundlePath, secret);

            treeContents.Wrap().WithJobDependencyBundleTree(_bundle);
        }

        private void treeContents_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            e.Node.ExpandAll();
        }

        private void treeContents_AfterCheck(object sender, TreeViewEventArgs e)
        {
            e.Node.Nodes.Descendants().ForEach(x => x.Checked = e.Node.Checked);
        }

        private async void btnImport_Click(object sender, EventArgs e)
        {
            //Jobs
            //Scripts
            //Assemblies
            //Credentials
            //ConnectionStrings
            await Await(async () =>
            {
                foreach (var script in _bundle.Scripts)
                {
                    if (!await Database.Scripts.AnyAsync(x => x.Id == script.Id))
                    {
                        Database.Scripts.Add(script);
                    }
                }

                foreach (var assemblyInfo in _bundle.JoinAssemblies())
                {
                    if (!await Database.AssemblyInfo.AnyAsync(x => x.Id == assemblyInfo.Id))
                    {
                        Database.AssemblyInfo.Add(assemblyInfo);
                        Database.Assemblies.Add(assemblyInfo.Linked);
                    }
                }

                foreach (var cred in _bundle.Credentials)
                {
                    if (!await Database.Credentials.AnyAsync(x => x.Id == cred.Id))
                    {
                        Database.Credentials.Add(cred);
                    }
                }

                foreach (var conn in _bundle.ConnectionStrings)
                {
                    if (!await Database.ConnectionStrings.AnyAsync(x => x.Id == conn.Id))
                    {
                        Database.ConnectionStrings.Add(conn);
                    }
                }

                await Database.SaveChangesAsync();
            });

            foreach (var bundleJob in _bundle.Jobs)
            {
                var typeInfo = CoreRuntime.GetRegisteredType(bundleJob.JobType);

                var options = (JobOptions)Activator.CreateInstance(typeInfo.JobOptionsType);

                try
                {
                    var id = Guid.NewGuid();

                    var job = Quartz.JobBuilder.Create(typeInfo.JobType)
                        .WithIdentity(id.ToString())
                        .StoreDurably(true)
                        .WithDescription(bundleJob.Name)
                        .WithDataMapDictionary(bundleJob.DataMap)
                        .Build();


                    Quartz.Collection.ISet<ITrigger> triggers = new Quartz.Collection.HashSet<ITrigger>();
                    foreach (var trig in bundleJob.Triggers)
                    {
                        triggers.Add(TriggerBuilder.Create()
                            .WithIdentity(id.ToString())
                            .WithCronSchedule(trig.Cron, x =>
                            {
                                if (trig.Cron == "1")
                                    x.WithMisfireHandlingInstructionFireAndProceed();
                                else if (trig.Cron == "-1")
                                    x.WithMisfireHandlingInstructionIgnoreMisfires();
                                else
                                    x.WithMisfireHandlingInstructionDoNothing();
                            })
                            .Build());
                    }

                    CoreSchedulerProxy.ScheduleJob(job, triggers, false);
                }
                catch (Exception ex)
                {
                    ex.OpenMessageBox();
                    return;
                }

            }

            MessageBox.Show("Package imported successfully");
        }
    }
}
