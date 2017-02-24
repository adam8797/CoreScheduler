using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoreScheduler.Client.Desktop.Forms.Package;
using CoreScheduler.Client.Desktop.Serializer;

namespace CoreScheduler.Client.Desktop.Forms
{
    public partial class RootForm : Form
    {
        public RootForm()
        {
            InitializeComponent();

            newJobToolStripMenuItem.Click += (e, o) => Open<JobBuilder>();
            scriptsToolStripMenuItem.Click += (e, o) => Open<ScriptManager>();
            jobExecutionHistoryToolStripMenuItem.Click += (e, o) => Open<RunHistory>();
            credentialManagerToolStripMenuItem.Click += (e, o) => Open<CredentialManager>();
            connectionStringsToolStripMenuItem.Click += (e, o) => Open<ConnectionStringManager>();
            assemblyManagerToolStripMenuItem.Click += (e, o) => Open<AssemblyManager>();
            jobListToolStripMenuItem.Click += (e, o) => Open<JobList>();
            triggersToolStripMenuItem.Click += (e, o) => Open<TriggerManager>();
            testFormToolStripMenuItem.Click += (e, o) => Open<TestForm>();
            savePackageToolStripMenuItem.Click += (e, o) => Open<ExportJobPackageForm>();
            openPackageToolStripMenuItem.Click += (e, o) => Open(new ImportJobPackageForm(null));
            mergePackageToolStripMenuItem.Click += (e, o) => Open<MergeJobPackageForm>();

#if DEBUG
            developmentToolsToolStripMenuItem.Visible = true;
#endif

        }

        protected override async void OnLoad(EventArgs e)
        {
#if TESTFORM
            Open<TestForm>();
            return;
#endif


            ClearStatus();
            StopLoading();
            await Task.Delay(500);

            LoadingForm loadForm;

            do
            {
                loadForm = new LoadingForm();
                loadForm.ShowDialog(this);
            } 
            while (loadForm.Retry);

#if DEBUG
            statusStrip.Visible = true;
            menuStrip.Visible = true;
#else
            bool loop = true;
            while (loop)
            {
                var loginForm = new LoginForm();
                loginForm.ShowDialog(this);

                switch (loginForm.LoginSuccessful)
                {
                    case -1:
                        Environment.Exit(0);
                        break;
                    case 0:
                        MessageBox.Show("Invalid username or password.");
                        break;
                    case 1:
                        statusStrip.Visible = true;
                        menuStrip.Visible = true;
                        loop = false;
                        break;
                    case 2:
                        menuStrip.Visible = true;
                        fileToolStripMenuItem.Visible = false;
                        manageToolStripMenuItem.Visible = false;
                        historyToolStripMenuItem.Visible = false;
                        loop = false;
                        break;
                }
            }
#endif

        }

        private void Open<T>() where T: Form, new()
        {
            Open(new T());
        }

        private void Open(Form f)
        {
            f.MdiParent = this;
            if (!f.IsDisposed)
                f.Show();
        }

        public void StartLoading()
        {
            loadingBar.Visible = true;
        }

        public void StopLoading()
        {
            loadingBar.Visible = false;
        }

        public void SetStatus(string status)
        {
            statusLabel.Text = status;
        }

        public void ClearStatus()
        {
            statusLabel.Text = "Ready";
        }

        private void encryptPackageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.Filter = "XML Files|*.xml";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string inSecret = "";
                if (JobSerializer.IsEncrypted(ofd.FileName))
                {
                    while (inSecret.Length < 6)
                    {
                        if (TextPrompt.PromptPassword("Input Bundle is encrypted. Enter the secret.", "Secret Required", out inSecret) != DialogResult.OK)
                            return;
                    }
                    
                }

                var bundle = JobSerializer.Read(ofd.FileName, inSecret);

                string outSecret = "";
                while (outSecret.Length < 6)
                {
                    if (TextPrompt.PromptPassword("Enter new secret for bundle", "Secret Required", out outSecret) != DialogResult.OK)
                        return;
                }
                var opts = new JobRenderOptions(outSecret);

                JobSerializer.Write(bundle, ofd.FileName, opts);

                MessageBox.Show("File Encrypted");
            }
        }
    }
}
