using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using CoreScheduler.Client.Desktop.Base;
using CoreScheduler.Client.Desktop.Serializer;
using CoreScheduler.Client.Desktop.Utilities;
using CoreScheduler.Client.Desktop.Utilities.Tree;
using CoreScheduler.Server;
using CoreScheduler.Server.Database;
using CoreScheduler.Server.Options;
using CoreScheduler.Server.Utilities;
using Quartz;

namespace CoreScheduler.Client.Desktop.Forms.Package
{
    public partial class ExportJobPackageForm : FormBase
    {
        private JobKey _currentJobKey = null;

        public ExportJobPackageForm()
        {
            InitializeComponent();
            jobTree.NodeMouseClick += TreeMouseFix;
        }

        protected override void OnLoad(EventArgs e)
        {
            jobTree.Wrap().WithBaseJobTree(false);
        }

        private async void jobTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Level > 0)
            {
                var db = new DatabaseContext();
                _currentJobKey = new JobKey(e.Node.Name);
                var jobDetail = CoreSchedulerProxy.GetJobDetail(_currentJobKey);
                var jobTypeInfo = new JobTypeInfo(jobDetail.JobType);
                var options = jobDetail.JobDataMap.Unpack(jobTypeInfo.JobOptionsType);

                lblJobName.Text = jobDetail.Description;
                if (options is ScriptJobOptions)
                {
                    var scriptOptions = (ScriptJobOptions) options;

                    var script = await db.Scripts.Where(x => x.Id == new Guid(scriptOptions.ScriptId)).Select(x => x.Name).SingleOrDefaultAsync();
                    lblPrimaryScript.Text = script;
                }
                else
                {
                    lblPrimaryScript.Text = "N/A";
                }

                dependencyTree.Nodes.Clear();

                await dependencyTree.Wrap().WithJobDependencyTreeAsync(_currentJobKey, (JobOptions)options);
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!renderOptions.ValidateSecret())
            {
                MessageBox.Show("Secret must be at least six characters");
                return;
            }

            var detail = CoreSchedulerProxy.GetJobDetail(_currentJobKey);
            var jobTypeInfo = new JobTypeInfo(detail.JobType);
            var options = detail.JobDataMap.Unpack(jobTypeInfo.JobOptionsType);
            var bundle = await JobDependencyBundle.Build(_currentJobKey, jobTypeInfo, (JobOptions)options);

            if (DialogResult.OK == saveFileDialog.ShowDialog())
            {
                JobSerializer.Write(bundle, saveFileDialog.FileName, renderOptions.GetOptions());
                MessageBox.Show("Bundle Saved");
            }

        }
    }
}
