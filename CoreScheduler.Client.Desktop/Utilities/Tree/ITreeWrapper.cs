using System.Windows.Forms;

namespace CoreScheduler.Client.Desktop.Utilities.Tree
{
    public interface ITreeWrapper
    {
        void Clear();
        TreeNodeCollection Nodes { get; }
    }

    public interface IImageTreeWrapper : ITreeWrapper
    {
        ImageList ImageList { set; }
    }
}