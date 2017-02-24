using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoreScheduler.Server.Utilities;

namespace CoreScheduler.Client.Desktop.Base
{
    public partial class SimpleManager<T, TContext> : FormBase where T: class, IGuidId, INamed, new() where TContext: DbContext
    {
        protected int TreeMaxWidth
        {
            get { return tree.MaximumSize.Width; }
            set { tree.MaximumSize = new Size(value, 0);}
        }

        protected int MinLevelForClick { get; set; }

        protected string ObjectName
        {
            get { return _objectName; }
            set
            {
                Text = value + " Manager";
                btnNew.Text = "New " + value;
                _objectName = value;
            }
        }

        /// <summary>
        /// Allows the user to delete the root node on the tree.
        /// You must override GetItemsToDelete() in order to use this function.
        /// </summary>
        protected bool DeleteRoot { get; set; }

        public SimpleManager()
        {
            InitializeComponent();
            MinLevelForClick = 1;
            DeleteRoot = false;
        }

        public SimpleManager(TContext context, Func<TContext, DbSet<T>> set) : this()
        {
            _context = context;
            if (_context != null)
                _dbSet = set(context);
        }

        private DbContext _context;
        private DbSet<T> _dbSet;
        private T _currentItem;
        private List<T> _cache;
        private string _objectName;

        protected DbSet<T> GetSet()
        {
            return _dbSet;
        }

        protected DbContext GetDatabase()
        {
            return _context;
        }

        protected void AddButton(Button b)
        {
            auxButtons.Controls.Add(b);
        }

        protected override async void OnLoad(EventArgs e)
        {
            if (_context != null)
                await Reload();
            tree.MaximumSize = new Size(TreeMaxWidth, 0);
        }

        protected void SetImageList(ImageList list)
        {
            tree.ImageList = list;
        }

        protected async Task Reload()
        {
            _cache = await Await(_dbSet.OrderByDescending(x => x.Name).ToListAsync());

            _currentItem = new T();

            RefreshEditor(_currentItem);

            tree.Nodes.Clear();

            PopulateTree(tree, _cache);
        }

        #region Virtual

        protected virtual void SaveExtra(T t)
        {
            
        }

        protected virtual async Task RemoveExtra(T t)
        {

        }

        /// <summary>
        /// Refresh the editor view
        /// </summary>
        protected virtual void RefreshEditor(T t)
        {
            // To Be Overridden
        }

        /// <summary>
        /// Update the given T with current vales from the editor
        /// </summary>
        /// <param name="t">Currently selected T</param>
        /// <returns>Updated T</returns>
        protected virtual void Update(T t)
        {
            // To Be Overridden
        }

        /// <summary>
        /// Populate a TreeView with the contents of a list of items
        /// </summary>
        /// <param name="tree">Tree View to populate</param>
        /// <param name="items">List of T which is to be represented by the tree</param>
        protected virtual void PopulateTree(TreeView tree, List<T> items)
        {
            // To Be Overridden
        }

        protected virtual IEnumerable<T> GetItemsToDelete(string nodeId, List<T> items)
        {
            return Enumerable.Empty<T>();
        }

        #endregion

        #region Events

        protected Action<T> NewTGenerated;

        #endregion

        #region Subscribed Events

        private void btnNew_Click(object sender, EventArgs e)
        {
            _currentItem = new T();

            if (NewTGenerated != null)
                NewTGenerated(_currentItem);

            RefreshEditor(_currentItem);
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (_currentItem == null)
                _currentItem = new T();

            Update(_currentItem);

            if (_currentItem.Id == Guid.Empty)
            {
                _currentItem.Id = Guid.NewGuid();
                _dbSet.Add(_currentItem);
            }

            SaveExtra(_currentItem);

            await Await(_context.SaveChangesAsync());

            await Reload();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Guid id;
            if (Guid.TryParse(e.Node.Name, out id))
            {
                var t = _cache.SingleOrDefault(x => x.Id == id);
                if (t == null)
                {
                    MessageBox.Show("An Error has occurred. The manager must close.");
                    Close();
                }

                _currentItem = t;

                RefreshEditor(_currentItem);
            }
        }

        private void tree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            tree.SelectedNode = e.Node;
        }

        private async void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DeleteRoot && tree.SelectedNode.Level == 0)
            {
                if (
                    MessageBox.Show("Are you sure you want to delete this whole collection?", "Confirm",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    foreach (var item in GetItemsToDelete(tree.SelectedNode.Name, _cache))
                    {
                        _dbSet.Remove(item);
                        await RemoveExtra(item);
                    }
                    await Await(_context.SaveChangesAsync());
                    await Reload();
                }
            }
            else if (tree.SelectedNode.Level > MinLevelForClick - 1)
            {
                var t = _cache.SingleOrDefault(x => x.Id == new Guid(tree.SelectedNode.Name));
                _dbSet.Remove(t);
                await RemoveExtra(t);
                await Await(_context.SaveChangesAsync());
                await Reload();
            }
        }

        private void treeContext_Opening(object sender, CancelEventArgs e)
        {
            if (DeleteRoot)
                deleteToolStripMenuItem.Enabled = true;
            else if (tree.SelectedNode.Level == MinLevelForClick - 1)
                deleteToolStripMenuItem.Enabled = false;
            else
                deleteToolStripMenuItem.Enabled = true;
        }

        private void copyIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tree.SelectedNode.Level > MinLevelForClick - 1)
            {
                Clipboard.SetText(tree.SelectedNode.Name);
                MessageBox.Show("GUID Copied to clipboard");
            }
        }
        #endregion

    }
}
