using System;
using System.Windows.Forms;

namespace CoreScheduler.Client.Desktop.Forms
{
    public sealed partial class TextPrompt : Form
    {
        public static DialogResult Prompt(string message, string caption, out string result, string def = "")
        {
            var p = new TextPrompt(message, caption, def);
            result = p.Prompt();
            return p.DialogResult;
        }

        public static DialogResult PromptPassword(string message, string caption, out string result, string def = "")
        {
            var p = new TextPrompt(message, caption, def);
            p.txtValue.PasswordChar = '•';
            result = p.Prompt();
            return p.DialogResult;
        }

        public TextPrompt(string message, string caption, string def = "")
        {
            InitializeComponent();
            groupBox.Text = message;
            Text = caption;
            txtValue.Text = def;
        }

        public string Prompt()
        {
            ShowDialog();
            return txtValue.Text.Trim();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
