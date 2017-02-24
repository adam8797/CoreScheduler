using System;
using System.Windows.Forms;

namespace CoreScheduler.Client.Desktop.Forms
{
    public partial class LoginForm : Form
    {
        public int LoginSuccessful { get; set; }

        public LoginForm()
        {
            InitializeComponent();
        }

        private async void btnOk_Click(object sender, EventArgs e)
        {
            var client = new RemoteService.Authentication.AuthenticationServiceClient();
            var res = await client.AuthenticateAsync(txtUsername.Text, txtPassword.Text, Environment.MachineName);

            LoginSuccessful = res ? 1 : 0;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            LoginSuccessful = -1;
            Close();
        }

        private void btnTools_Click(object sender, EventArgs e)
        {
            LoginSuccessful = 2;
            Close();
        }
    }
}
