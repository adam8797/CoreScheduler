using System.Windows.Forms;

namespace CoreScheduler.Client.Desktop.Utilities.Tree
{
    public class TreeViewWrapper : IImageTreeWrapper
    {
        private readonly TreeView _treeView;

        public TreeViewWrapper(TreeView treeView)
        {
            _treeView = treeView;
        }

        public void Clear()
        {
            _treeView.Nodes.Clear();
        }

        public TreeNodeCollection Nodes { get { return _treeView.Nodes; } }

        public ImageList ImageList
        {
            set
            {
                _treeView.ImageList = value;
            }
        }
    }
}