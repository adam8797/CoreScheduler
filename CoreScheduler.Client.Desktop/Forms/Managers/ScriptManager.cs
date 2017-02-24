using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoreScheduler.Client.Desktop.Base;
using CoreScheduler.Client.Desktop.Template;
using CoreScheduler.Client.Desktop.Utilities;
using CoreScheduler.Client.Desktop.Utilities.Tree;
using CoreScheduler.Server;
using CoreScheduler.Server.Database;
using CoreScheduler.Server.Utilities;

namespace CoreScheduler.Client.Desktop.Forms
{
    public partial class ScriptManager : FormBase
    {
        #region Constructors

        public ScriptManager()
        {
            InitializeComponent();
            scriptBrowser.NodeMouseClick += TreeMouseFix;
            //scriptBrowser.ImageList = FileIcons;
        }

        public ScriptManager(Guid scriptId) : this()
        {
            _openOnLoad = scriptId;
        }

        #endregion

        #region Instance Variables

        private Guid _openOnLoad;
        private Script _currentScript;
        private bool _edited;

        /// <summary>
        /// Local Cache of scripts, binned by JobTypeGuid
        /// </summary>
        private List<Script> _scriptCache;

        #endregion

        #region Private Methods

        private async Task NewScript(Type type)
        {
            string fileName;
            if (TextPrompt.Prompt("Enter a new file name", "New " + type + " Script", out fileName) == DialogResult.OK)
            {
                var info = new JobTypeInfo(type);

                if (!fileName.EndsWith(info.SourceFileExtension))
                    fileName += info.SourceFileExtension;

                _currentScript = new Script()
                {
                    Id = Guid.NewGuid(),
                    Name = fileName,
                    JobTypeGuid = type.GUID
                };

                _currentScript.ScriptSource = await ScriptTemplates.GetTemplate(type);

                RefreshEditor();
            }

        }

        protected override async void OnLoad(EventArgs e)
        {
            await ReloadScripts();

            if (_openOnLoad != Guid.Empty)
            {
                var script = _scriptCache.SingleOrDefault(x => x.Id == _openOnLoad);

                if (script == null)
                {
                    MessageBox.Show("The selected script no longer exists");
                    await ReloadScripts();
                    return;
                }

                _currentScript = script;

                RefreshEditor();
            }
        }

        private async Task ReloadScripts()
        {
            // Clear old info
            newToolStripMenuItem.DropDownItems.Clear();
            
            // Start building the new image list
            var imgList = ImageListBuilder.Create();

            // Loop each type of job
            foreach (var registeredType in Server.CoreRuntime.GetRegisteredTypes())
            {
                // Add the New Script menu
                var type = registeredType.JobType;
                newToolStripMenuItem.DropDownItems.Add(string.Format("New {0} Script", registeredType.Name),
                    imgList.ExtractBitmap(registeredType.SourceFileExtension),
                    async (sender, args) => await NewScript(type));

            }

            _scriptCache = await Await(Database.Scripts.ToListAsync());

            _scriptCache.Count();

            scriptBrowser.Wrap().WithFileTree(_scriptCache.Cast<IFile>().ToList());

            RefreshEditor();
        }



        private void RefreshEditor()
        {
            if (_currentScript != null)
            {
                editor.Text = _currentScript.ScriptSource;
                Text = "Script Editor - " + _currentScript.Name;
                _edited = false;

                ExpandNode(FindNode(scriptBrowser.Nodes, _currentScript.Id.ToString()));

                editor.Styler =
                    Server.CoreRuntime.GetRegisteredTypes()
                        .Single(x => x.Guid == _currentScript.JobTypeGuid)
                        .JobType.LoadStyler();
            }
        }

        private async Task SaveCurrentScript()
        {
            _edited = false;

            _currentScript.ScriptSource = editor.Text;

            if (_currentScript.Id == Guid.Empty)
                _currentScript.Id = Guid.NewGuid();

            if (await Await(Database.Scripts.AnyAsync(x => x.Name == _currentScript.Name && x.Id != _currentScript.Id)))
            {
                MessageBox.Show("Name already taken. Please use the Save As menu to choose a new name.");
                return;
            }

            if (!await Await(Database.Scripts.AnyAsync(x => x.Id == _currentScript.Id)))
                Database.Scripts.Add(_currentScript);

            await Await(Database.SaveChangesAsync());

            await ReloadScripts();
        }


        private TreeNode FindNode(TreeNodeCollection nodes, string key)
        {
            if (nodes.ContainsKey(key))
            {
                return nodes[key];
            }

            foreach (var subNode in nodes.Cast<TreeNode>())
            {
                return FindNode(subNode.Nodes, key);
            }

            return null;
        }

        private void ExpandNode(TreeNode node)
        {
            if (node == null || node.Level == 0)
                return;

            node.Expand();
            ExpandNode(node.Parent);
        }

        #endregion

        #region Script Browser

        private async void scriptBrowser_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Guid scriptId;
            if (DetermineType(e.Node, out scriptId) == NodeType.Script)
            {
                var script = _scriptCache.SingleOrDefault(x => x.Id == scriptId);

                if (script == null)
                {
                    MessageBox.Show("The selected script no longer exists");
                    await ReloadScripts();
                    return;
                }

                _currentScript = script;

                RefreshEditor();
            }
        }

        private async void scriptBrowser_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (_edited)
            {
                if (MessageBox.Show("You have unsaved changes. Do you want to save now?", "Unsaved Changes",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                {
                    _openOnLoad = new Guid(e.Node.Name);
                    await SaveCurrentScript();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        #endregion

        #region Context Strip

        private void fileActions_Opening(object sender, CancelEventArgs e)
        {
            switch (DetermineType(scriptBrowser.SelectedNode))
            {
                case NodeType.JobType:
                    fileActions.Items.ForEach<ToolStripItem>(x => x.Enabled = false);
                    break;
                case NodeType.Folder:
                    fileActions.Items.ForEach<ToolStripItem>(x => x.Enabled = false);
                    break;
                case NodeType.Script:
                    fileActions.Items.ForEach<ToolStripItem>(x => x.Enabled = true);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private async void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scriptBrowser.SelectedNode.BeginEdit();

            return;

            var script = _scriptCache.SingleOrDefault(x => x.Id == new Guid(scriptBrowser.SelectedNode.Name));

            string newName;
            while (TextPrompt.Prompt("Enter a new name for " + script.Name, "Rename", out newName, script.Name) ==
                DialogResult.OK)
            {
                var type = Server.CoreRuntime.GetRegisteredTypes()
                        .FirstOrDefault(x => x.Guid == script.JobTypeGuid);

                if (type != null && !newName.EndsWith(type.SourceFileExtension))
                {
                    newName += type.SourceFileExtension;
                }

                if (await Await(Database.Scripts.AnyAsync(x => x.Name == newName && x.Id != script.Id)))
                {
                    MessageBox.Show(string.Format("Name {0} is already taken. Try again.", newName));
                    continue;
                }

                script.Name = newName;

                await Await(Database.SaveChangesAsync());

                await ReloadScripts();

                break;
            }
        }

        private async void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (
                MessageBox.Show(string.Format("Are you sure you want to delete {0}? Any jobs associated with this script will break.", scriptBrowser.SelectedNode.Text), "Confirm Delete", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information) == DialogResult.Yes)
            {
                var script = await Await(Database.Scripts.SingleOrDefaultAsync(x => x.Id == new Guid(scriptBrowser.SelectedNode.Name)));

                Database.Scripts.Remove(script);

                await Await(Database.SaveChangesAsync());

                await ReloadScripts();
            }
        }

        #endregion

        #region Menu Strip

        private async void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await SaveCurrentScript();
        }

        private async void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string name;
            if (TextPrompt.Prompt("Enter a file name", "Save As", out name) == DialogResult.OK)
            {
                _currentScript.Name = name;

                _currentScript = _currentScript.ShallowCopy();

                _currentScript.Id = Guid.NewGuid();
                await SaveCurrentScript();
            }
        }

        private async void reloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await ReloadScripts();
        }

        #endregion

        private void editor_TextChanged(object sender, EventArgs e)
        {
            _edited = true;

            if (!Text.EndsWith("*"))
                Text += "*";
        }

        private async void moveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var script = _scriptCache.SingleOrDefault(x => x.Id == new Guid(scriptBrowser.SelectedNode.Name));

            if (script == null)
                return;

            string newPath;
            if (TextPrompt.Prompt("Please enter a new path for this script", "Move Script", out newPath,
                    script.TreeDirectory) == DialogResult.OK)
            {
                script.TreeDirectory = newPath;
            }

            await Await(Database.SaveChangesAsync());

            await ReloadScripts();

        }

        private async void scriptBrowser_DragDrop(object sender, DragEventArgs e)
        {
            // Retrieve the client coordinates of the drop location.
            Point targetPoint = scriptBrowser.PointToClient(new Point(e.X, e.Y));

            // Retrieve the node at the drop location.
            TreeNode targetNode = scriptBrowser.GetNodeAt(targetPoint);

            // Retrieve the node that was dragged.
            TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));

            // Confirm that the node at the drop location is not 
            // the dragged node and that target node isn't null
            // (for example if you drag outside the control)
            if (!draggedNode.Equals(targetNode) && targetNode != null)
            {
                // Remove the node from its current 
                // location and add it to the node at the drop location.
                draggedNode.Remove();
                targetNode.Nodes.Add(draggedNode);
                // Expand the node at the location 
                // to show the dropped node.
                targetNode.Expand();

                var s = _scriptCache.Single(x => x.Id == new Guid(draggedNode.Name));
                s.TreeDirectory = string.Join("/", targetNode.FullPath.Split('/').Skip(1));

                RemoveEmptyFolders(scriptBrowser.Nodes);

                await Await(Database.SaveChangesAsync());
            }
        }

        private void scriptBrowser_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void scriptBrowser_DragOver(object sender, DragEventArgs e)
        {
            ClearBackground(scriptBrowser.Nodes);
            Point p = scriptBrowser.PointToClient(new Point(e.X, e.Y));
            TreeNode node = scriptBrowser.GetNodeAt(p.X, p.Y);
            if (DetermineType(node) == NodeType.Folder || InLineage(node, (TreeNode)e.Data.GetData(typeof(TreeNode))))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;

            node.BackColor = SystemColors.Highlight;
            node.ForeColor = SystemColors.HighlightText;
        }

        private void ClearBackground(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.BackColor != Color.White)
                    node.BackColor = Color.White;

                if (node.ForeColor != Color.Black)
                    node.ForeColor = Color.Black;

                ClearBackground(node.Nodes);
            }
        }

        private void RemoveEmptyFolders(TreeNodeCollection nodes)
        {
            foreach (var node in nodes.Cast<TreeNode>())
            {
                if (node == null)
                    continue;

                if (DetermineType(node) == NodeType.Folder && node.Nodes.Count == 0)
                    node.Remove();
                else
                    RemoveEmptyFolders(node.Nodes);
            }
        }

        private enum NodeType
        {
            JobType,
            Folder,
            Script
        }

        private NodeType DetermineType(TreeNode n)
        {
            if (n.Level == 0)
                return NodeType.JobType;

            Guid id;
            if (Guid.TryParse(n.Name, out id))
                return NodeType.Script;


            return NodeType.Folder;
        }

        private NodeType DetermineType(TreeNode n, out Guid id)
        {
            if (n.Level == 0)
            {
                id = Guid.Empty;
                return NodeType.JobType;
            }

            if (Guid.TryParse(n.Name, out id))
                return NodeType.Script;

            id = Guid.Empty;
            return NodeType.Folder;
        }

        private bool InLineage(TreeNode ancestor, TreeNode decendant)
        {
            if (ancestor.Nodes.Contains(decendant))
                return true;

            if (decendant.Parent == null)
                return false;

            return InLineage(ancestor, decendant.Parent);
        }

        private async void scriptBrowser_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (DetermineType(e.Node) == NodeType.Script)
            {
                var script =
                    _scriptCache.SingleOrDefault(x => x.Id == new Guid(e.Node.Name));

                var type = CoreRuntime.GetRegisteredTypes().FirstOrDefault(x => x.Guid == script.JobTypeGuid);

                var newName = e.Label;

                if (type != null && !newName.EndsWith(type.SourceFileExtension))
                {
                    newName += type.SourceFileExtension;
                }

                if (await Await(Database.Scripts.AnyAsync(x => x.Name == newName && x.Id != script.Id)))
                {
                    MessageBox.Show(string.Format("Name {0} is already taken. Try again.", newName));
                    e.CancelEdit = true;
                    return;
                }

                script.Name = newName;

                await Await(Database.SaveChangesAsync());

                await ReloadScripts();
            }
        }

        private async void duplicateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DetermineType(scriptBrowser.SelectedNode) == NodeType.Script)
            {
                var script =
                    _scriptCache.SingleOrDefault(x => x.Id == new Guid(scriptBrowser.SelectedNode.Name));

                var dupe = script.ShallowCopy();
                dupe.Id = Guid.NewGuid();
                dupe.Name = script.Name + " copy";

                await Await(Database.SaveChangesAsync());

                await ReloadScripts();
            }
        }

        private void copyIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DetermineType(scriptBrowser.SelectedNode) == NodeType.Script)
            {
                Clipboard.SetText(scriptBrowser.SelectedNode.Name);
                MessageBox.Show("Script GUID Copied to Clipboard");
            }
        }
    }
}
