using System;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.Logging;
using CoreScheduler.Client.Desktop.Utilities;
using CoreScheduler.Server.Database;
using Quartz;
using Quartz.Impl.Matchers;

namespace CoreScheduler.Client.Desktop.Forms
{
    public partial class LoadingForm : Form
    {
        public LoadingForm()
        {
            InitializeComponent();
        }

        public bool Retry { get; set; }

        protected override async void OnLoad(EventArgs e)
        {
            var logger = LogManager.GetLogger<LoadingForm>();
            
            progressBar.Value = 10;
            await Task.Delay(100);

            int step = 30;

            try
            {
                progressBar.Value = 10;
                await Task.Delay(100);


                statusLabel.Text = "Loading Database....";
                var db = new DatabaseContext();
                if (await db.Scripts.AnyAsync())
                    logger.Debug("Database contains some scripts");

                progressBar.Value = step;
            }
            catch (Exception ex)
            {
                var result = MessageBox.Show("There was an error connecting to the Database\n\n" + ex, "Fatal Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                if (result == DialogResult.Abort)
                    Environment.Exit(1);
                else if (result == DialogResult.Retry)
                {
                    Retry = true;
                    Close();
                }
            }


            try
            {
                statusLabel.Text = "Loading Jobs...";
                var jobs = Server.CoreRuntime.GetRegisteredTypes();
                foreach (var jobTypeInfo in jobs)
                {
                    var inst = Activator.CreateInstance(jobTypeInfo.JobType);
                    logger.Debug(inst);
                    progressBar.Value += step/jobs.Count;
                    await Task.Delay(100);
                }

                statusLabel.Text = "Connecting to Quartz instance...";
                var keys = CoreSchedulerProxy.GetJobKeys(GroupMatcher<JobKey>.AnyGroup());
                foreach (var jobKey in keys)
                {
                    logger.Debug(CoreSchedulerProxy.GetJobDetail(jobKey));
                    progressBar.Value += step / keys.Count;
                    await Task.Delay(100);
                }

                progressBar.Value = 100;
            }
            catch (Exception ex)
            {
                var result = MessageBox.Show("There was an error connecting to the CORE Server\n\n" + ex, "Fatal Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                if (result == DialogResult.Abort)
                    Environment.Exit(1);
                else if (result == DialogResult.Retry)
                {
                    Retry = true;
                    Close();
                }
            }
            

            await Task.Delay(1000);
            Retry = false;
            Close();
        }
    }
}
