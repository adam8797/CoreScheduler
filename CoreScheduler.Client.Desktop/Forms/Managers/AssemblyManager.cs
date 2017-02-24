using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoreScheduler.Client.Desktop.Base;
using CoreScheduler.Client.Desktop.Utilities.Tree;
using CoreScheduler.Server.Database;

namespace CoreScheduler.Client.Desktop.Forms
{
    public partial class AssemblyManager : AssemblyManagerBase
    {
        public AssemblyManager()
        {
            InitializeComponent();
            ObjectName = "Assembly";
            DeleteRoot = true;

            NewTGenerated += NewTGenerated_Fire;
            var bulkAdd = new Button()
            {
                Name = "btnBulkAdd",
                Size = new Size(75, 23),
                Text = "Bulk Add",
            };
            bulkAdd.Click += btnBulkAdd_Click;
            AddButton(bulkAdd);
        }

        private void NewTGenerated_Fire(ReferenceAssemblyInfo referenceAssembly)
        {
            if (openDll.ShowDialog() == DialogResult.OK && File.Exists(openDll.FileName))
            {
                var asm = Assembly.ReflectionOnlyLoadFrom(openDll.FileName);

                referenceAssembly.FullName = asm.FullName;
                referenceAssembly.Name = asm.GetName().Name;
                referenceAssembly.Version = asm.GetName().Version.ToString();
                referenceAssembly.Linked = new ReferenceAssembly()
                {
                    Data = File.ReadAllBytes(openDll.FileName),
                    FileName = Path.GetFileName(openDll.FileName)
                };
            }
        }

        protected override void SaveExtra(ReferenceAssemblyInfo t)
        {
            t.Linked.Id = t.Id;
            ((DatabaseContext) GetDatabase()).Assemblies.Add(t.Linked);
        }

        protected override async Task RemoveExtra(ReferenceAssemblyInfo t)
        {
            var tempAsm = new ReferenceAssembly
            {
                Id = t.Id
            };
            ((DatabaseContext) GetDatabase()).Assemblies.Attach(tempAsm);
            ((DatabaseContext) GetDatabase()).Assemblies.Remove(tempAsm);
        }

        protected override void RefreshEditor(ReferenceAssemblyInfo t)
        {
            txtName.Text = t.Name;
            lblFullName.Text = t.FullName;
            lblVersion.Text = t.Version;
        }

        protected override void Update(ReferenceAssemblyInfo t)
        {
            t.Name = txtName.Text;
            t.FullName = lblFullName.Text;
            t.Version = lblVersion.Text;
        }

        protected override IEnumerable<ReferenceAssemblyInfo> GetItemsToDelete(string nodeId, List<ReferenceAssemblyInfo> items)
        {
            //return items.Where(x => x.Group == nodeId);
            return new ReferenceAssemblyInfo[0];
        }

        protected override void PopulateTree(TreeView tree, List<ReferenceAssemblyInfo> items)
        {
            tree.Wrap().WithFileTree(items.Cast<IFile>().ToList());
        }

        private async void btnBulkAdd_Click(object sender, EventArgs e)
        {
            openDll.Multiselect = true;
            if (openDll.ShowDialog() == DialogResult.OK)
            {
                string group;
                if (TextPrompt.Prompt("Enter a group name for imported DLLs", "Enter a name", out group) != DialogResult.OK)
                {
                    return;
                }

                foreach (var openDllFileName in openDll.FileNames)
                {
                    var asm = Assembly.ReflectionOnlyLoadFrom(openDllFileName);
                    var id = Guid.NewGuid();
                    var referenceAssembly = new ReferenceAssembly
                    {
                        Id = id,
                        Data = File.ReadAllBytes(openDllFileName),
                        FileName = Path.GetFileName(openDllFileName),
                    };

                    var assemblyInfo = new ReferenceAssemblyInfo()
                    {
                        Id = id,
                        TreeDirectory = group,
                        FullName = asm.FullName,
                        Name = asm.GetName().Name,
                        Version = asm.GetName().Version.ToString(),
                    };

                    ((DatabaseContext) GetDatabase()).Assemblies.Add(referenceAssembly);
                    GetSet().Add(assemblyInfo);
                }

                await Await(GetDatabase().SaveChangesAsync());

                await Reload();
            }
        }
    }

    public class AssemblyManagerBase : SimpleManager<ReferenceAssemblyInfo, DatabaseContext>
    {
#if DESIGNER
        public AssemblyManagerBase() : base(null, x => x.Assemblies) {}
#else
        public AssemblyManagerBase() : base(new DatabaseContext(), x => x.AssemblyInfo) {}
#endif
    }
}
