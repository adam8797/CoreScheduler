using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Common.Logging;
using CoreScheduler.Client.Desktop.Base;
using CoreScheduler.Client.Desktop.Controls;
using CoreScheduler.Client.Desktop.Utilities;
using CoreScheduler.Client.Desktop.Utilities.Tree;
using CoreScheduler.Server;
using CoreScheduler.Server.Options;
using CoreScheduler.Server.Utilities;
using Quartz;

namespace CoreScheduler.Client.Desktop.Forms
{
    public partial class JobEditor : FormBase
    {
        private readonly JobKey _jobKey;
        private IJobDetail _jobDetail;

        private readonly List<LargeTriggerEditor> _editors;
        private readonly Dictionary<string, TriggerState> _status;

        public JobEditor(JobKey jobKey)
        {
            _jobKey = jobKey;
            _status = new Dictionary<string, TriggerState>();
            _editors = new List<LargeTriggerEditor>();
            InitializeComponent();
        }

        protected override async void OnLoad(EventArgs e)
        {
            _jobDetail = CoreSchedulerProxy.GetJobDetail(_jobKey);

            foreach (var trigger in CoreSchedulerProxy.GetTriggersOfJob(_jobDetail.Key)
                .OfType<ICronTrigger>())
            {
                tabs.TabPages.Add(BuildPage(trigger));
            }

            properties.SelectedObject = _jobDetail.Wrap();

            var jobTypeInfo = new JobTypeInfo(_jobDetail.JobType);

            txtJobType.Text = jobTypeInfo.Name + " [" + jobTypeInfo.JobType.FullName + "]";
            txtJobDescription.Text = jobTypeInfo.Description;
            txtCategory.Text = jobTypeInfo.Category;

            jobIcon.Image = ImageListBuilder.Create()
                .ExtractBitmap(jobTypeInfo.SourceFileExtension, ImageListBuilder.Size.Jumbo);
            var backstop = DateTime.Now.Subtract(TimeSpan.FromDays(7));
            var runs = (await
                    Await(
                        Database.Events.Where(
                                x => x.JobId == _jobKey.Name && x.Timestamp > backstop)
                            .ToListAsync()))
                .Bin(x => x.RunId);

            eventTree.Wrap().WithRunTree(runs);
            eventTree.ImageList = TreeUtils.WithRunTreeImageListBuilder().Build();
        }

        private TabPage BuildPage(ICronTrigger trigger)
        {
            TabPage page;
            LargeTriggerEditor editor;
            if (trigger != null)
            {
                if (string.IsNullOrEmpty(trigger.Description))
                    page = new TabPage("Untitled Trigger");
                else
                    page = new TabPage("Trigger: " + trigger.Description);
                editor = new LargeTriggerEditor(trigger);
                _status.Add(editor.Key.Name, TriggerState.Update);
            }
            else
            {
                page = new TabPage("New Trigger");
                editor = new LargeTriggerEditor(null);
                _status.Add(editor.Key.Name, TriggerState.Create);
            }

            _editors.Add(editor);
            editor.Location = new Point(70, 34);
            editor.ForecastFor = new TimeSpan(120);

            var deleteButton = new Button()
            {
                FlatStyle  = FlatStyle.Flat,
                Size = new Size(32, 32),
                BackgroundImage = ImageListBuilder.Create().ExtractBitmap(SHStockIconId.Delete, ImageListBuilder.Size.Large),
                Location = new Point(6, 6)
            };

            deleteButton.FlatAppearance.BorderSize = 0;

            deleteButton.Click += (sender, args) =>
            {
                tabs.TabPages.Remove(page);
                if (_status[editor.Key.Name] == TriggerState.Update) //If trigger exists already
                    _status[editor.Key.Name] = TriggerState.Delete; //mark for deletion

                if (_status[editor.Key.Name] == TriggerState.Create) //If trigger is new
                {
                    _status.Remove(editor.Key.Name); //Just delete the sucker
                    _editors.Remove(editor);
                }
            };

            page.BackColor = Color.White;
            page.Controls.Add(editor);
            page.Controls.Add(deleteButton);


            return page;
        }

        private void btnOpenScript_Click(object sender, EventArgs e)
        {
            var info = new JobTypeInfo(_jobDetail.JobType);
            if (typeof(ScriptJobOptions).IsAssignableFrom(info.JobOptionsType))
            {
                var details = _jobDetail.JobDataMap.Unpack<ScriptJobOptions>();
                var editor = new ScriptManager(new Guid(details.ScriptId));
                editor.MdiParent = MdiParent;
                editor.Show();
            }
        }

        private void btnNewTrigger_Click(object sender, EventArgs e)
        {
            tabs.TabPages.Add(BuildPage(null));
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            foreach (var triggerEditor in _editors)
            {
                if (!_status.ContainsKey(triggerEditor.Key.Name))
                {
                    LogManager.GetLogger<JobEditor>().Debug("Status list did not contain entry for trigger " + triggerEditor.Key.Name);
                };

                var t = triggerEditor
                    .BuildBuilder()
                    .ForJob(_jobKey)
                    .Build();

                switch (_status[triggerEditor.Key.Name])
                {
                    case TriggerState.Delete:
                        CoreSchedulerProxy.UnscheduleJob(triggerEditor.Key);
                        break;
                    case TriggerState.Update:
                        CoreSchedulerProxy.RescheduleJob(triggerEditor.Key, t);
                        break;
                    case TriggerState.Create:
                        CoreSchedulerProxy.ScheduleJob(t);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            var job = ((JobDetailsProxyObject)properties.SelectedObject).Unwrap();

            CoreSchedulerProxy.AddJob(job, true);

            MessageBox.Show("Changes saved");
            await ReloadParent();
        }

        private enum TriggerState
        {
            Delete,
            Update,
            Create
        }
    }
}
