using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CoreScheduler.Api;
using CoreScheduler.Client.Desktop.Base;
using CoreScheduler.Server.Database;
using Microsoft.Data.ConnectionUI;

namespace CoreScheduler.Client.Desktop.Forms
{
    public partial class ConnectionStringManager : ConnectionStringManagerBase
    {
        public ConnectionStringManager()
        {
            InitializeComponent();
            ObjectName = "Connection";
        }

        protected override void OnLoad(EventArgs e)
        {
            comboType.Items.Add(ConnectionStringType.MsSql);

            base.OnLoad(e);
        }

        protected override void RefreshEditor(ConnectionString t)
        {
            txtName.Text = t.Name;
            txtConnectionString.Text = t.Value;
            comboType.SelectedIndex = (int) t.ServerType;
        }

        protected override void Update(ConnectionString t)
        {
            t.Name = txtName.Text;
            t.Value = txtConnectionString.Text;
            t.ServerType = (ConnectionStringType)comboType.SelectedIndex;
        }

        protected override void PopulateTree(TreeView tree, List<ConnectionString> items)
        {
            foreach (var type in items.Select(x => x.ServerType).Distinct())
            {
                tree.Nodes.Add(((int)type).ToString(), type.ToString());

                foreach (var conn in items.Where(x => x.ServerType == type))
                {
                    tree.Nodes[((int) type).ToString()].Nodes.Add(conn.Id.ToString(), conn.Name);
                }
            }
        }

        private void btnBuild_Click(object sender, EventArgs e)
        {
            using (var dialog = new DataConnectionDialog())
            {
                dialog.DataSources.Add(DataSource.SqlDataSource);
                DialogResult userChoice = DataConnectionDialog.Show(dialog);
                if (userChoice == DialogResult.OK)
                {
                    txtConnectionString.Text = dialog.ConnectionString;
                }
            }
        }
    }
    


    //Base class just to make the designer happy
    public class ConnectionStringManagerBase : SimpleManager<ConnectionString, DatabaseContext>
    {
#if DESIGNER
        public ConnectionStringManagerBase() : base(null, x => x.ConnectionStrings) {}
#else
        public ConnectionStringManagerBase() : base(new DatabaseContext(), x => x.ConnectionStrings) {}
#endif
    }
}
