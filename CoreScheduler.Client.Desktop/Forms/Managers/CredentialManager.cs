using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CoreScheduler.Client.Desktop.Base;
using CoreScheduler.Client.Desktop.Utilities;
using CoreScheduler.Server.Database;

namespace CoreScheduler.Client.Desktop.Forms
{
    public partial class CredentialManager : CredentialManagerBase
    {
        public CredentialManager()
        {
            InitializeComponent();
            SetImageList(ImageListBuilder.Create("imageres.dll")
                .WithStockIcon(SHStockIconId.Lock) // Lock
                .WithStockIcon(SHStockIconId.Key)// Key
                .Build());

            ObjectName = "Credential";
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = chkShowPassword.Checked ? (char)0 : '•';
        }

        protected override void Update(Credential t)
        {
            t.Name = txtCredName.Text;
            t.Username = txtUserName.Text;
            t.Password = txtPassword.Text;
            t.Domain = txtDomain.Text;
        }

        protected override void PopulateTree(TreeView tree, List<Credential> items)
        {
            tree.Nodes.Add("root", "Credentials", 0, 0);

            foreach (var credential in items)
            {
                tree.Nodes[0].Nodes.Add(credential.Id.ToString(), credential.Name, 1, 1);
            }

            tree.Nodes[0].Expand();
        }

        protected override void RefreshEditor(Credential t)
        {
            chkShowPassword.Checked = false;
            txtCredName.Text = t.Name;
            txtUserName.Text = t.Username;
            txtPassword.Text = t.Password;
            txtDomain.Text = t.Domain;
        }
    }

    //Base class just to make the designer happy
    public class CredentialManagerBase : SimpleManager<Credential, DatabaseContext>
    {
#if DESIGNER
        public CredentialManagerBase() : base(null, x => x.Credentials) { }
#else
        public CredentialManagerBase() : base(new DatabaseContext(), x => x.Credentials) {}
#endif
    }
}
