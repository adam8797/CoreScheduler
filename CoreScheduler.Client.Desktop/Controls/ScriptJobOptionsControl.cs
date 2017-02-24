using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using CoreScheduler.Client.Desktop.Utilities;
using CoreScheduler.Client.Desktop.Utilities.Tree;
using CoreScheduler.Server.Database;
using CoreScheduler.Server.Jobs;
using CoreScheduler.Server.Options;
using CoreScheduler.Server.Utilities;

namespace CoreScheduler.Client.Desktop.Controls
{
    [EditorForJobType(typeof(ScriptJob))]
    public partial class ScriptJobOptionsControl : JobOptionsControl
    {
        public ScriptJobOptionsControl()
        {
            InitializeComponent();
        }

        public List<ConnectionString> ConnectionStrings { get; set; }
        public List<Credential> Credentials { get; set; }
        public Dictionary<Guid, List<Script>> Scripts { get; set; }
        public List<ReferenceAssemblyInfo> Dlls { get; set; }

        protected override async void OnLoad(EventArgs e)
        {
            var db = new DatabaseContext();

            if (ConnectionStrings.IsNullOrEmpty())
                ConnectionStrings = await db.ConnectionStrings.ToListAsync();

            if (Credentials.IsNullOrEmpty())
                Credentials = await db.Credentials.ToListAsync();

            contextOptions.ConnectionStrings = ConnectionStrings;
            contextOptions.Credentials = Credentials;

            if (Scripts.IsNullOrEmpty())
                Scripts = (await db.Scripts.ToListAsync()).Bin(x => x.JobTypeGuid);

            if (Dlls.IsNullOrEmpty())
                Dlls = await db.AssemblyInfo.ToListAsync();

            var imgList = ImageListBuilder.Create();
            imgList.WithExtensionIcon(".dll");

            scriptBrowser.Wrap().WithFileTree(Scripts.SelectMany(x => x.Value).Cast<IFile>().ToList());
            treeDllReferences.Wrap().WithFileTree(Dlls.Cast<IFile>().ToList());
            base.OnLoad(e);
        }

        public override JobOptions BuildOptions(JobOptions options)
        {
            base.BuildOptions(options);

            contextOptions.BuildOptions(options);

            var scriptOptions = options as ScriptJobOptions;
            if (scriptOptions != null)
            {
                scriptOptions.DllReferences =
                    treeDllReferences.Nodes.Descendants()
                        .Where(x => x.Checked)
                        .Where(x =>
                        {
                            Guid id;
                            return Guid.TryParse(x.Name, out id);
                        })
                        .Select(x => x.Name)
                        .ToArray();

                scriptOptions.ScriptReferences =
                    scriptBrowser.Nodes.Descendants()
                        .Where(x => x.Checked && x.Level > 0)
                        .Where(x =>
                        {
                            Guid id;
                            return Guid.TryParse(x.Name, out id);
                        })
                        .Select(x => x.Name)
                        .ToArray();
            }
            return options;
        }

        private void treeScriptReferences_AfterCheck(object sender, TreeViewEventArgs e)
        {
            var tree = (TreeView) sender;

            if (e.Action != TreeViewAction.Unknown)
            {
                if (e.Node.Nodes.Count > 0)
                    CheckAllChildNodes(e.Node, e.Node.Checked);
            }
        }

        private void CheckAllChildNodes(TreeNode treeNode, bool nodeChecked)
        {
            foreach (TreeNode node in treeNode.Nodes)
            {
                node.Checked = nodeChecked;
                if (node.Nodes.Count > 0)
                {
                    CheckAllChildNodes(node, nodeChecked);
                }
            }
        }
    }
}
