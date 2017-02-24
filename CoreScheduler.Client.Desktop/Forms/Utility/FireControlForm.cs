using System;
using System.Windows.Forms;
using CoreScheduler.Client.Desktop.Base;
using CoreScheduler.Client.Desktop.Utilities;
using Quartz;

namespace CoreScheduler.Client.Desktop.Forms
{
    public partial class FireControlForm : FormBase
    {
        private readonly JobKey _key;

        public FireControlForm(JobKey key)
        {
            _key = key;
            InitializeComponent();
        }

        private async void btnFire_Click(object sender, System.EventArgs e)
        {
            var extraData = new JobDataMap();

            if (chkStream.Checked)
            {
                var port = RedirectedConsole.ReservePort();
                var requestId = Guid.NewGuid().ToString();

                var client = new RemoteService.Scheduler.SchedulerExtensionServiceClient();
                await client.RegisterForStreamAsync(requestId, 
                    RedirectedConsole.GetLocalIpAddress(),
                    port);

                var rc = new RedirectedConsole(port, requestId);
                Open(rc);

                extraData.Add("JobOptions.ConsoleStreaming", requestId);
            }

            if (chkEmail.Checked)
            {
                extraData.Add("JobOptions.EmailOnFinish", txtEmail.Text);
            }

            CoreSchedulerProxy.TriggerJob(_key, extraData);

            if (!chkStream.Checked)
                MessageBox.Show("Job has been scheduled");
            Close();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
