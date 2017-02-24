using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoreScheduler.Client.Desktop.Base;
using CoreScheduler.Client.Desktop.Controls;
using CoreScheduler.Client.Desktop.Utilities;
using CoreScheduler.Server;
using CronExpressionDescriptor;
using Quartz;
using Quartz.Impl.Matchers;

namespace CoreScheduler.Client.Desktop.Forms
{
    public partial class TriggerManager : FormBase
    {
        public TriggerManager()
        {
            InitializeComponent();
        }

        private List<ITrigger> _triggers;
        private ITrigger _currentTrigger;

        protected override void OnLoad(EventArgs e)
        {
            var keys = CoreSchedulerProxy.GetTriggerKeys(GroupMatcher<TriggerKey>.AnyGroup());
            var cron = tree.Nodes.Add("cron", "Cron Triggers");
            _triggers = new List<ITrigger>();
            _currentTrigger = null;
            tree.Nodes.Clear();

            foreach (var triggerKey in keys)
            {
                var trigger = CoreSchedulerProxy.GetTrigger(triggerKey);
                _triggers.Add(trigger);
                if (trigger is ICronTrigger)
                {
                    cron.Nodes.Add(triggerKey.Name,
                        trigger.Description + " (Cron: " +
                        ExpressionDescriptor.GetDescription(((ICronTrigger)trigger).CronExpressionString) + ")");
                }
            }

            lblJob.Text = "";
            lblStatus.Text = "";
            tree.Nodes.Add(cron);
        }

        protected override async Task Reload()
        {
            var newEditor = new LargeTriggerEditor();
            editor.Replace(newEditor);
            editor = newEditor;
            OnLoad(null);
        }

        private void tree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            tree.SelectedNode = e.Node;
        }

        private void tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            _currentTrigger = _triggers.SingleOrDefault(x => x.Key.Name == e.Node.Name);

            if (_currentTrigger == null)
                return;

            editor.LoadTrigger((ICronTrigger)_currentTrigger);
            var jobInfo = CoreSchedulerProxy.GetJobDetail(_currentTrigger.JobKey);

            lblJob.Text = string.Format("{0}: {1}", (new JobTypeInfo(jobInfo.JobType).Name), jobInfo.Description);
            lblStatus.Text = CoreSchedulerProxy.GetTriggerState(_currentTrigger.Key).ToString();
        }

        private void btnResume_Click(object sender, EventArgs e)
        {
            CoreSchedulerProxy.ResumeTrigger(_currentTrigger.Key);
            MessageBox.Show("Trigger has been resumed successfully.");
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            CoreSchedulerProxy.PauseTrigger(_currentTrigger.Key);
            MessageBox.Show("Trigger has been paused successfully.");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEditJob_Click(object sender, EventArgs e)
        {
            if (_currentTrigger != null)
                Open(new JobEditor(_currentTrigger.JobKey));
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CoreSchedulerProxy.RescheduleJob(_currentTrigger.Key,
                editor.BuildBuilder().ForJob(_currentTrigger.JobKey).Build());
            MessageBox.Show("Trigger has been updated successfully.");
        }
    }
}
