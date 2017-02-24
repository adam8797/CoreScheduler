using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoreScheduler.Client.Desktop.Base;
using CoreScheduler.Client.Desktop.Utilities;
using CoreScheduler.Client.Desktop.Utilities.Tree;
using CoreScheduler.Server.Database;
using CoreScheduler.Server.Utilities;
using Quartz;
using Quartz.Impl.Triggers;

namespace CoreScheduler.Client.Desktop.Forms
{
    public partial class JobList : FormBase
    {
        public JobList()
        {
            InitializeComponent();
        }

        protected override async void OnLoad(EventArgs e)
        {
            ReloadTree();
        }

        private void ReloadTree()
        {
            tree.Wrap().WithBaseJobTree();
        }

        private async Task RefreshNode(TreeNode jobNode, DatabaseContext db)
        {
            var jobKey = new JobKey(jobNode.Name);
            jobNode.Nodes.Clear();

            #region Triggers
            var triggersNode = jobNode.Nodes.Add(jobKey.Name + "_Triggers", "Triggers", 6, 6);
            foreach (var trigger in CoreSchedulerProxy.GetTriggersOfJob(jobKey))
            {
                TreeNode triggerNode;
                if (trigger is CronTriggerImpl)
                {
                    var crontrig = ((ICronTrigger) trigger);

                    triggerNode = triggersNode.Nodes.Add(trigger.Key.Name,
                        "Cron Trigger: " +
                        CronExpressionDescriptor.ExpressionDescriptor.GetDescription(crontrig.CronExpressionString));

                    triggerNode.Nodes.Add("Cron Expression: " + crontrig.CronExpressionString);
                }
                else
                    triggerNode = triggersNode.Nodes.Add(trigger.Key.Name,
                        "Trigger");

                var trigState = CoreSchedulerProxy.GetTriggerState(trigger.Key);

                triggerNode.Text += " [" + trigState + "]";

                switch (trigState)
                {
                    case TriggerState.Normal:
                    case TriggerState.None:
                        triggerNode.SelectedImageIndex = triggerNode.ImageIndex = 3;
                        break;
                    case TriggerState.Complete:
                        triggerNode.SelectedImageIndex = triggerNode.ImageIndex = 5;
                        break;
                    case TriggerState.Paused:
                        triggerNode.SelectedImageIndex = triggerNode.ImageIndex = 1;
                        break;
                    case TriggerState.Error:
                    case TriggerState.Blocked:
                        triggerNode.SelectedImageIndex = triggerNode.ImageIndex = 2;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            #endregion

            #region Last Run

            var lastRunNode = jobNode.Nodes.Add(jobKey.Name + "_Lastrun", "Last Run", 7, 7);

            var lastRunId =
                await db.Events.Where(x => x.JobId == jobKey.Name)
                    .OrderByDescending(x => x.Timestamp)
                    .Select(x => x.RunId)
                    .FirstOrDefaultAsync();

            var events = await Await(db.Events.Where(x => x.RunId == lastRunId).OrderBy(x => x.RunOrder).ToListAsync());

            if (events.Any())
            {
                lastRunNode.Wrap().WithRunTree(events.Bin(x => x.RunId));
            }

            #endregion
        }

        private void contextMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            contextMenuStrip.Enabled = tree.SelectedNode.Level == 1;
        }

        private void tree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            tree.SelectedNode = e.Node;
        }

        private void fireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Open(new FireControlForm(SelectedJobKey()));
        }

        private JobKey SelectedJobKey()
        {
            return new JobKey(tree.SelectedNode.Name);
        }

        private async void pauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CoreSchedulerProxy.PauseJob(SelectedJobKey());
            MessageBox.Show("Job has been paused");
            await Await(RefreshNode(tree.SelectedNode, Database));
        }

        private async void resumeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CoreSchedulerProxy.ResumeJob(SelectedJobKey());
            MessageBox.Show("Job has resumed");
            await Await(RefreshNode(tree.SelectedNode, Database));
        }

        private async void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var expandTo = tree.SelectedNode.Name;
            await Await(RefreshNode(tree.SelectedNode, new DatabaseContext()));

            foreach (var treeNode in tree.Nodes.Cast<TreeNode>())
            {
                treeNode.SearchAndExpandAllUnder(expandTo);
            }
        }

        private void viewDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var details = new JobEditor(new JobKey(tree.SelectedNode.Name));
            details.MdiParent = MdiParent;
            details.Show();
        }

        private void expandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tree.SelectedNode.ExpandAll();
        }

        private async void tree_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Level == 1)
            {
                await Await(RefreshNode(e.Node, Database));
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm deletion of Job?", "Confirm?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                CoreSchedulerProxy.DeleteJob(SelectedJobKey());
                MessageBox.Show("Job & Trigger have been deleted");
                ReloadTree();
            }
        }
    }
}
