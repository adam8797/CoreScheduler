using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CoreScheduler.Server.Database;
using CoreScheduler.Server.Options;
using CoreScheduler.Server.Utilities;

namespace CoreScheduler.Client.Desktop.Controls
{
    public partial class ContextOptions : JobOptionsControl
    {
        public ContextOptions()
        {
            InitializeComponent();
        }

        public List<ConnectionString> ConnectionStrings;
        public List<Credential> Credentials;

        protected override async void OnLoad(EventArgs e)
        {
            var db = new DatabaseContext();

            if (ConnectionStrings.IsNullOrEmpty())
                ConnectionStrings = await db.ConnectionStrings.ToListAsync();

            if (Credentials.IsNullOrEmpty())
                Credentials = await db.Credentials.ToListAsync();

            listCredentials.DataSource = () => db.Credentials.ToList();
            listSql.DataSource = () => db.ConnectionStrings.ToList();
        }

        public override JobOptions BuildOptions(JobOptions options)
        {
            var scriptOptions = options as ScriptJobOptions;
            if (scriptOptions != null)
            {
                scriptOptions.Context = new Server.Options.ContextOptions
                {
                    Enable = chkContextEnable.Checked,
                    LoggerEnable = chkIncludeLogger.Checked,
                    EventsEnable = chkIncludeJobEvents.Checked,
                    ConnectionStrings = listSql.GetItems()
                        .Cast<ConnectionString>()
                        .Select(x => x.Id.ToString())
                        .ToArray(),
                    Credentials = listCredentials.GetItems()
                        .Cast<Credential>()
                        .Select(x => x.Id.ToString())
                        .ToArray()
                };



                return scriptOptions;
            }

            return options;
        }

        private void chkContextEnable_CheckedChanged(object sender, EventArgs e)
        {
            var en = chkContextEnable.Checked;

            chkSqlEnable.Enabled = en;
            listSql.Enabled = chkSqlEnable.Checked;

            chkIncludeLogger.Enabled = en;

            chkIncludeJobEvents.Enabled = en;

            chkIncludeCredentials.Enabled = en;
            listCredentials.Enabled = chkIncludeCredentials.Checked;
        }

        private void chkSqlEnable_CheckedChanged(object sender, EventArgs e)
        {
            listSql.Enabled = chkSqlEnable.Checked;
        }

        private void chkIncludeCredentials_CheckedChanged(object sender, EventArgs e)
        {
            listCredentials.Enabled = chkIncludeCredentials.Checked;
        }
    }
}
