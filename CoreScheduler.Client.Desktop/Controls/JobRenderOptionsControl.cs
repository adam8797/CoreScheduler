using System;
using System.Windows.Forms;
using CoreScheduler.Client.Desktop.Serializer;

namespace CoreScheduler.Client.Desktop.Controls
{
    public partial class JobRenderOptionsControl : UserControl
    {
        public JobRenderOptionsControl()
        {
            InitializeComponent();
        }

        public JobRenderOptions GetOptions()
        {
            return new JobRenderOptions()
            {
                EncryptCredentials = chkEncCred.Checked,
                ExportCredentials = chkExportCred.Checked,
                EncryptConnectionStrings = chkEncConn.Checked,
                ExportConnectionStrings = chkExportConn.Checked,
                Secret = txtSecret.Text
            };
        }

        public bool ValidateSecret()
        {
            return !((chkEncConn.Checked || chkEncCred.Checked) && txtSecret.Text.Length < 6);
        }

        private void chkExportCred_CheckedChanged(object sender, EventArgs e)
        {
            chkEncCred.Enabled = chkExportCred.Checked;
        }

        private void chkExportConn_CheckedChanged(object sender, EventArgs e)
        {
            chkEncConn.Enabled = chkExportConn.Checked;

        }
    }
}
