using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CoreScheduler.Client.Desktop.Serializer;
using CoreScheduler.Client.Desktop.Utilities;

namespace CoreScheduler.Client.Desktop.Forms.Package
{
    public partial class MergeJobPackageForm : Form
    {
        private List<string> _files;

        public MergeJobPackageForm()
        {
            InitializeComponent();
            _files = new List<string>();
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            foreach (var fileName in openFileDialog.FileNames)
            {
                fileList.Items.Add(Path.GetFileName(fileName));
                _files.Add(fileName);
            }
        }

        private void btnAddPackage_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
        }

        private void btnClearList_Click(object sender, EventArgs e)
        {
            _files.Clear();
            fileList.Items.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!renderOptions.ValidateSecret())
            {
                MessageBox.Show("Secret must be at least six characters");
                return;
            }
            
            var baseBundle = new JobDependencyBundle();

            // secret is defined out here, so that if the same secret was 
            // used for each file, we just assume and try it.
            string secret = "";
            foreach (var file in _files)
            {
                if (JobSerializer.IsEncrypted(file))
                {
                    while (!JobSerializer.CheckPassword(file, secret))
                    {
                        if (TextPrompt.PromptPassword("Enter the secret for " + Path.GetFileName(file),
                                "Secret required",
                                out secret) != DialogResult.OK)
                        {
                            return;
                        }
                    }
                }

                var bundle = JobSerializer.Read(file, secret);

                // Merge all the things together.
                // All except Job implement IGuidId, which means we don't need to tell it how to merg.

                baseBundle.Jobs = baseBundle.Jobs.Merge(bundle.Jobs, (x, y) => x.Name == y.Name).ToList();
                baseBundle.AssemblyInfo = baseBundle.AssemblyInfo.Merge(bundle.AssemblyInfo).ToList();
                baseBundle.AssemblyData = baseBundle.AssemblyData.Merge(bundle.AssemblyData).ToList();
                baseBundle.ConnectionStrings = baseBundle.ConnectionStrings.Merge(bundle.ConnectionStrings).ToList();
                baseBundle.Credentials = baseBundle.Credentials.Merge(bundle.Credentials).ToList();
                baseBundle.Scripts = baseBundle.Scripts.Merge(bundle.Scripts).ToList();
            }

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                JobSerializer.Write(baseBundle, saveFileDialog.FileName, renderOptions.GetOptions());
                MessageBox.Show("File Saved");
                Close();
            }
        }
    }
}
