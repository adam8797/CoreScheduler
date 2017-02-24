using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoreScheduler.Client.Desktop.Base;
using CoreScheduler.Client.Desktop.Controls;
using CoreScheduler.Client.Desktop.Template;
using CoreScheduler.Client.Desktop.Utilities;
using CoreScheduler.Server;
using CoreScheduler.Server.Attributes;
using CoreScheduler.Server.Database;
using CoreScheduler.Server.Options;
using CoreScheduler.Server.Utilities;

namespace CoreScheduler.Client.Desktop.Forms
{
    public partial class JobBuilder : FormBase
    {
        public JobBuilder()
        {
            InitializeComponent();
            //jobTypeTree.ImageList = FileIcons;
        }

        protected override void OnLoad(EventArgs e)
        {
            var types = CoreRuntime.GetRegisteredTypes();
            var categories = types.Select(x => x.Category).Distinct().OrderByDescending(x => x);
            var imgListBuilder = ImageListBuilder.Create();

            foreach (var job in types.Where(x => string.IsNullOrEmpty(x.Category)))
            {
                int index;
                imgListBuilder.WithExtensionIcon(job.SourceFileExtension, out index);
                jobTypeTree.Nodes.Add(job.Guid.ToString(), job.Name, index, index);
            }

            foreach (var category in categories)
            {
                if (!string.IsNullOrEmpty(category))
                {
                    jobTypeTree.Nodes.Add(category, category);

                    var category1 = category;
                    foreach (var job in types.Where(x => x.Category == category1))
                    {
                        int index;
                        imgListBuilder.WithExtensionIcon(job.IconFileExtension, out index);
                        jobTypeTree.Nodes[category].Nodes.Add(job.Guid.ToString(), job.Name, index, index);
                    }

                    jobTypeTree.Nodes[category].ImageIndex =
                        jobTypeTree.Nodes[category].Nodes.Cast<TreeNode>().First().ImageIndex;
                    jobTypeTree.Nodes[category].SelectedImageIndex =
                        jobTypeTree.Nodes[category].Nodes.Cast<TreeNode>().First().SelectedImageIndex;
                }
            }

            jobTypeTree.ImageList = imgListBuilder.Build();
        }

        private Type _currentJobType;

        private async Task LoadScripts(Type type)
        {
            _currentJobType = type;
            var scripts = await Await(Database.Scripts.Where(x => x.JobTypeGuid == type.GUID).ToListAsync());
            comboScript.Items.Clear();

            comboScript.Items.Add("New " + new JobTypeInfo(type).Name + " Script");
            comboScript.SelectedIndex = 0;

            foreach (var script in scripts)
            {
                comboScript.Items.Add(script);
            }
        }

        private async void jobTypeTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Debug.WriteLine(e.Node.ImageKey);
            Debug.WriteLine(e.Node.SelectedImageKey);

            if (e.Node.Level == 0)
                return;

            var jobTypes = CoreRuntime.GetRegisteredTypes();
            var target = jobTypes.Single(x => x.Guid == new Guid(e.Node.Name));
            await ChangeJobType(target.JobType);
        }

        private async Task ChangeJobType(Type type)
        {
            optionsPanel.Controls.Clear();
            if (type.HasAttribute<JobDescriptionAttribute>())
                txtJobType.Text = type.GetAttribute<JobDescriptionAttribute>().Value;
            else if (type.HasAttribute<JobNameAttribute>())
                txtJobType.Text = type.GetAttribute<JobNameAttribute>().Value;
            else
                txtJobType.Text = type.FullName;

            scriptEditor.Styler = type.LoadStyler();
            scriptEditor.Text = await ScriptTemplates.GetTemplate(type);
            var editor = GetEditor(type);
            if (editor is ScriptJobOptionsControl)
            {
                var seditor = (ScriptJobOptionsControl) editor;
                await Await(async () =>
                {
                    var db = new DatabaseContext();
                    seditor.ConnectionStrings = await db.ConnectionStrings.ToListAsync();
                    seditor.Credentials = await db.Credentials.ToListAsync();
                    seditor.Dlls = await db.AssemblyInfo.ToListAsync();
                    seditor.Scripts = (await db.Scripts.ToListAsync()).Bin(x => x.JobTypeGuid);
                });
            }
            optionsPanel.Controls.Add(GetEditor(type));

            await LoadScripts(type);
        }

        private void comboScript_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboScript.SelectedIndex > 0)
            {
                EditorEnabled(false);
                txtScriptName.Text = ((Script) comboScript.SelectedItem).Name;
            }
            else
            {
                EditorEnabled(true);
                txtScriptName.Enabled = comboScript.SelectedIndex == 0;
                txtScriptName.Text = "";
            }
        }

        private void EditorEnabled(bool b)
        {
            if (b && tabControl.TabCount == 2)
            {
                tabControl.TabPages.Add(editorPage);
            }

            if (!b && tabControl.TabCount == 3)
            {
                tabControl.TabPages.RemoveAt(2);
            }
        }

        private void txtScriptName_Leave(object sender, EventArgs e)
        {
            var ext = new JobTypeInfo(_currentJobType).SourceFileExtension;

            if (!txtScriptName.Text.EndsWith(ext))
                txtScriptName.Text += ext;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(scriptEditor.Text.Trim()) && comboScript.SelectedIndex == 0)
            {
                MessageBox.Show("You must type a script, or pick a script.");
                return;
            }

            Script script;
            try
            {
                // Save the script
                if (comboScript.SelectedIndex > 0)
                {
                    // Use old script
                    script = (Script) comboScript.SelectedItem;
                }
                else
                {
                    script = new Script()
                    {
                        Name = txtScriptName.Text,
                        Id = Guid.NewGuid(),
                        JobTypeGuid = _currentJobType.GUID,
                        ScriptSource = scriptEditor.Text
                    };

                    Database.Scripts.Add(script);
                    await Await(Database.SaveChangesAsync());
                }
            }
            catch (Exception ex)
            {
                ex.OpenMessageBox();
                Database.RejectChanges();
                return;
            }

            var jobBuilder = Quartz.JobBuilder.Create(_currentJobType);
            var options = (JobOptions)Activator.CreateInstance(new JobTypeInfo(_currentJobType).JobOptionsType);

            try
            {
                var id = Guid.NewGuid();

                if (options is ScriptJobOptions)
                {
                    var s = (ScriptJobOptions) options;
                    s.ScriptId = script.Id.ToString();
                }
                ((JobOptionsControl) optionsPanel.Controls[0]).BuildOptions(options);
                
                var optionsDictionary = new Dictionary<string, object>();

                optionsDictionary.Pack(options);

                var job = jobBuilder.WithIdentity(id.ToString())
                    .StoreDurably(true)
                    .WithDescription(txtJobName.Text)
                    .WithDataMapDictionary(optionsDictionary)
                    .Build();


                var trigger = triggerEditor.Build();

                if (trigger != null)
                    CoreSchedulerProxy.ScheduleJob(job, trigger);
                else
                    CoreSchedulerProxy.AddJob(job, false);
            }
            catch (Exception ex)
            {
                ex.OpenMessageBox();
                return;
            }

            MessageBox.Show("Job saved successfully");
            Close();
            //ToDo: Open Job Details
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
