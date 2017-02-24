using System.Windows.Forms;

namespace CoreScheduler.Client.Desktop.Utilities.Tree
{
    public class SingleTreeNodeWrapper : ITreeWrapper
    {
        private readonly TreeNode _node;

        public SingleTreeNodeWrapper(TreeNode node)
        {
            _node = node;
        }

        public void Clear()
        {
            _node.Nodes.Clear();
        }

        public TreeNodeCollection Nodes
        {
            get { return _node.Nodes; }
        }
    }

    public class TreeNodeWrapper : IImageTreeWrapper
    {
        private readonly TreeNode _node;

        public TreeNodeWrapper(TreeNode node)
        {
            _node = node;
        }

        public void Clear()
        {
            _node.Nodes.Clear();
        }

        public TreeNodeCollection Nodes
        {
            get { return _node.Nodes; }
        }

        public ImageList ImageList
        {
            set
            {
                if (_node.TreeView != null)
                    _node.TreeView.ImageList = value;
            }
        }
    }
}