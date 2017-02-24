using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoreScheduler.Api;
using CoreScheduler.Client.Desktop.Base;
using CoreScheduler.Client.Desktop.Utilities;
using CoreScheduler.Client.Desktop.Utilities.Tree;
using CoreScheduler.Server.Utilities;
using Humanizer;
using Humanizer.Localisation;
using Quartz;

namespace CoreScheduler.Client.Desktop.Forms
{
    public partial class RunHistory : FormBase
    {
        #region Constructors

        public RunHistory()
        {
            InitializeComponent();

            Text = "Run History - Last " + _interval.Humanize(maxUnit: TimeUnit.Year, minUnit: TimeUnit.Hour);

            runTree.ImageList = TreeUtils.WithRunTreeImageListBuilder().Build();

            debugToolStripMenuItem.Click += (sender, args) => ChangeEventLevel(EventLevel.Debug);
            infoToolStripMenuItem.Click += (sender, args) => ChangeEventLevel(EventLevel.Info);
            warningToolStripMenuItem.Click += (sender, args) => ChangeEventLevel(EventLevel.Warning);
            errorToolStripMenuItem.Click += (sender, args) => ChangeEventLevel(EventLevel.Error);
            fatalToolStripMenuItem.Click += (sender, args) => ChangeEventLevel(EventLevel.Fatal);

            oneHourToolStripMenuItem.Click +=
                (sender, args) => ChangeTimeInterval((ToolStripMenuItem) sender, new TimeSpan(1, 0, 0));
            twelveHourToolStripMenuItem.Click +=
                (sender, args) => ChangeTimeInterval((ToolStripMenuItem)sender, new TimeSpan(12, 0, 0));
            oneDayToolStripMenuItem.Click +=
                (sender, args) => ChangeTimeInterval((ToolStripMenuItem)sender, new TimeSpan(1, 0, 0, 0));
            twoDaysToolStripMenuItem.Click +=
                (sender, args) => ChangeTimeInterval((ToolStripMenuItem)sender, new TimeSpan(2, 0, 0, 0));
            threeDaysToolStripMenuItem.Click +=
                (sender, args) => ChangeTimeInterval((ToolStripMenuItem)sender, new TimeSpan(3, 0, 0, 0));
            oneWeekToolStripMenuItem.Click +=
                (sender, args) => ChangeTimeInterval((ToolStripMenuItem)sender, new TimeSpan(7, 0, 0, 0));
            oneMonthToolStripMenuItem.Click +=
                (sender, args) => ChangeTimeInterval((ToolStripMenuItem)sender, TimeSpan.FromDays(30));
            sixMonthsToolStripMenuItem.Click +=
                (sender, args) => ChangeTimeInterval((ToolStripMenuItem)sender, TimeSpan.FromDays(180));
            oneYearToolStripMenuItem.Click +=
                (sender, args) => ChangeTimeInterval((ToolStripMenuItem)sender, TimeSpan.FromDays(365));
            allTimeToolStripMenuItem.Click +=
                (sender, args) => ChangeTimeInterval((ToolStripMenuItem)sender, TimeSpan.Zero);
        }

        #endregion

        #region Overrides

        protected override void OnLoad(EventArgs e)
        {
            ReloadTree();
        }

        #endregion

        #region Instance Variables

        private EventLevel _minLevel = EventLevel.Info;
        private TimeSpan _interval = new TimeSpan(1, 0, 0, 0);
        private string _jobId;

        #endregion

        #region Instance Methods

        private void ReloadTree()
        {
            jobTree.Wrap().WithBaseJobTree(false);
        }

        private async Task RefreshNode(TreeNode node)
        {
            var jobKey = new JobKey(node.Name);
            node.Nodes.Clear();

            DateTime backstop = DateTime.Now.Subtract(_interval);

            if (_interval == TimeSpan.Zero)
                backstop = new DateTime(1979, 10, 12); // Bonus points: why is this date important?

            var events =
                await
                    Await(
                        Database.Events
                            .Where(x => x.JobId == jobKey.Name)
                            .Where(x => x.EventLevel >= _minLevel || x.EventLevel == EventLevel.Success)
                            .Where(x => x.Timestamp > backstop)
                            .OrderByDescending(x => x.Timestamp)
                            .ToListAsync());

            runTree.Nodes.Clear();
            runTree.Wrap().WithRunTree(events.Bin(x => x.RunId));

        }

        #endregion

        #region Events

        private async void ChangeTimeInterval(ToolStripMenuItem sender, TimeSpan interval)
        {
            timeIntervalToolStripMenuItem.DropDownItems.Cast<ToolStripMenuItem>().ForEach(x => x.Checked = false);
            sender.Checked = true;
            
            if (interval == TimeSpan.Zero)
                Text = "Run History - All";
            else
                Text = "Run History - Last " + interval.Humanize(maxUnit: TimeUnit.Year, minUnit: TimeUnit.Hour);
            
            _interval = interval;

            var job = jobTree.Nodes.Descendants().SingleOrDefault(x => x.Name == _jobId);
            if (job != null)
                await RefreshNode(job);
        }

        private async void ChangeEventLevel(EventLevel level)
        {
            runTree.Nodes.Clear();

            _minLevel = level;
            debugToolStripMenuItem.Checked = false;
            infoToolStripMenuItem.Checked = false;
            warningToolStripMenuItem.Checked = false;
            errorToolStripMenuItem.Checked = false;
            fatalToolStripMenuItem.Checked = false;

            switch (level)
            {
                case EventLevel.Debug:
                    debugToolStripMenuItem.Checked = true;
                    break;
                case EventLevel.Info:
                    infoToolStripMenuItem.Checked = true;
                    break;
                case EventLevel.Warning:
                    warningToolStripMenuItem.Checked = true;
                    break;
                case EventLevel.Error:
                    errorToolStripMenuItem.Checked = true;
                    break;
                case EventLevel.Fatal:
                    fatalToolStripMenuItem.Checked = true;
                    break;
            }

            await RefreshNode(jobTree.Nodes.Descendants().Single(x => x.Name == _jobId));
        }

        private async void jobTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Level > 0)
            {
                _jobId = e.Node.Name;
                await RefreshNode(e.Node);
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReloadTree();
        }

        #endregion
        
    }
}
