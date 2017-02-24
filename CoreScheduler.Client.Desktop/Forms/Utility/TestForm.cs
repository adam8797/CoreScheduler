using System;
using System.Linq;
using System.Windows.Forms;
using CoreScheduler.Client.Desktop.Utilities;
using CoreScheduler.Client.Desktop.Utilities.Tree;
using CoreScheduler.Server.Database;
using Microsoft.Data.ConnectionUI;
using Quartz;
using Quartz.Impl.Matchers;

namespace CoreScheduler.Client.Desktop.Forms
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            btnUpdateIcons_Click(this, null);

            var builder = ImageListBuilder.Create()
                .SetSize(32,32)
                .SetColorDepth(ColorDepth.Depth32Bit);

            foreach (var stockIconId in Enum.GetValues(typeof(SHStockIconId)).Cast<SHStockIconId>())
            {
                if (stockIconId < SHStockIconId.MaxIcons)
                {
                    int index;
                    builder.WithStockIcon(stockIconId, ImageListBuilder.Size.Large, out index);
                    stockList.Items.Add(stockIconId.ToString(), stockIconId.ToString(), index);
                }
            }
            stockList.LargeImageList = builder.Build();

            jobsTree.Wrap().WithBaseJobTree(false);
        }

        private void btnUpdateIcons_Click(object sender, EventArgs e)
        {
            var b = ImageListBuilder.Create(txtDll.Text, chkUseLarge.Checked);
            iconList.Items.Clear();

            if (txtDll.Text.EndsWith(".dll"))
            {
                for (int i = 0; !b.ErrorState; i++)
                {
                    b.WithDllIcon(i);
                    iconList.Items.Add(i.ToString(), i.ToString(), i);
                }
            }
            else
            {
                b.WithExtensionIcon(txtDll.Text);
                iconList.Items.Add("", 0);
            }

            iconList.LargeImageList = b.Build();

        }

        bool TryGetDataConnectionStringFromUser(out string outConnectionString)
        {
            using (var dialog = new DataConnectionDialog())
            {
                // OR, if you want only certain data sources to be available
                // (e.g. only SQL Server), do something like this instead: 
                dialog.DataSources.Add(DataSource.SqlDataSource);

                // The way how you show the dialog is somewhat unorthodox; `dialog.ShowDialog()`
                // would throw a `NotSupportedException`. Do it this way instead:
                DialogResult userChoice = DataConnectionDialog.Show(dialog);

                // Return the resulting connection string if a connection was selected:
                if (userChoice == DialogResult.OK)
                {
                    outConnectionString = dialog.ConnectionString;
                    return true;
                }
                else
                {
                    outConnectionString = null;
                    return false;
                }
            }
        }

        private void btnCon_Click(object sender, EventArgs e)
        {
            string con;
            if (TryGetDataConnectionStringFromUser(out con))
                txtCon.Text = con;
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            var ctx = new DatabaseContext();

            if (chkScripts.Checked)
                ctx.Database.ExecuteSqlCommand("DELETE FROM Scripts");

            if (chkScripts.Checked)
                ctx.Database.ExecuteSqlCommand("DELETE FROM JobEvents");

            if (chkScripts.Checked)
                ctx.Database.ExecuteSqlCommand("DELETE FROM Credentials");

            if (chkScripts.Checked)
                ctx.Database.ExecuteSqlCommand("DELETE FROM ConnectionStrings");

            if (chkAssemblies.Checked)
            {
                ctx.Database.ExecuteSqlCommand("DELETE FROM AssemblyInfo");
                ctx.Database.ExecuteSqlCommand("DELETE FROM AssemblyData");
            }


            if (chkJobs.Checked)
            {
                var jobs = CoreSchedulerProxy.GetJobKeys(GroupMatcher<JobKey>.AnyGroup()).ToList();
                CoreSchedulerProxy.DeleteJobs(jobs);
            }

            if (chkTriggers.Checked)
            {
                var triggers = CoreSchedulerProxy.GetTriggerKeys(GroupMatcher<TriggerKey>.AnyGroup()).ToList();
                CoreSchedulerProxy.UnscheduleJobs(triggers);
            }


            MessageBox.Show("Done");
        }

        private void btnFireAll_Click(object sender, EventArgs e)
        {
            btnFireAll.Enabled = false;
            foreach (var node in jobsTree.Nodes.Descendants())
            {
                if (node.Checked)
                {
                    CoreSchedulerProxy.TriggerJob(new JobKey(node.Name));
                }
            }
            btnFireAll.Enabled = true;
        }
    }
}
