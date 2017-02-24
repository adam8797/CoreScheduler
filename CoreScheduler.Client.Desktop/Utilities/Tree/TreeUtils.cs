using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CoreScheduler.Api;
using CoreScheduler.Server;
using CoreScheduler.Server.Database;

namespace CoreScheduler.Client.Desktop.Utilities.Tree
{
    public static class TreeUtils
    {
        public static void DrillAndPlaceNode(ITreeWrapper root, TreeNode newNode, string[] components, int folderIcon)
        {
            if (components.Length == 0)
            {
                root.Nodes.Add(newNode);
                return;
            }

            var folder = components[0];

            TreeNode nextNode;

            if (root.Nodes.ContainsKey(folder))
                nextNode = root.Nodes[folder];
            else
                nextNode = root.Nodes.Add(folder, folder, folderIcon, folderIcon);

            DrillAndPlaceNode(new TreeNodeWrapper(nextNode), newNode, components.Skip(1).ToArray(), folderIcon);
        }

        public static ImageListBuilder WithRunTreeImageListBuilder()
        {
            return ImageListBuilder.Create("imageres.dll")
                .WithStockIcon(SHStockIconId.Info) // Info
                .WithStockIcon(SHStockIconId.Warning) // Warning
                .WithStockIcon(SHStockIconId.Error) // Critical
                .WithDllIcon(8, "comres.dll") //Success
                .WithDllIcon(16, "comres.dll"); //Success With Warnings
        }

        public static ImageListBuilder WithBaseJobTreeImageListBuilder()
        {
            return WithRunTreeImageListBuilder()
                .WithDllIcon(137, "shell32.dll")  // Ok
                .WithDllIcon(239, "shell32.dll") // clock
                .WithStockIcon(SHStockIconId.ClockPage); // clock page
        }

        public static void SetEventLevelImageIndex(TreeNode sub, EventLevel level)
        {
            switch (level)
            {
                case EventLevel.Debug:
                    sub.SelectedImageIndex = sub.ImageIndex = 0;
                    sub.NodeFont = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Italic);
                    sub.ForeColor = SystemColors.GrayText;
                    break;
                case EventLevel.Info:
                    sub.SelectedImageIndex = sub.ImageIndex = 0;
                    break;
                case EventLevel.Warning:
                    sub.SelectedImageIndex = sub.ImageIndex = 1;
                    break;
                case EventLevel.Error:
                    sub.SelectedImageIndex = sub.ImageIndex = 2;
                    break;
                case EventLevel.Fatal:
                    sub.SelectedImageIndex = sub.ImageIndex = 2;
                    sub.BackColor = Color.Red;
                    break;
                case EventLevel.Success:
                    sub.SelectedImageIndex = sub.ImageIndex = 3;
                    break;
            }
        }

        public static ITreeWrapper WrapSingle(this TreeNode node)
        {
            return new SingleTreeNodeWrapper(node);
        }

        public static IImageTreeWrapper Wrap(this TreeNode node)
        {
            return new TreeNodeWrapper(node);
        }

        public static IImageTreeWrapper Wrap(this TreeView view)
        {
            return new TreeViewWrapper(view);
        }

        /// <summary>
        /// Removes nodes with no children
        /// </summary>
        /// <param name="root">Node to recurse down</param>
        /// <param name="safeAfter">Number of levels to traverse until nodes are safe from pruning.</param>
        /// <param name="depth">Current depth. Used in recursion.</param>
        public static void Prune(this ITreeWrapper root, int safeAfter, int depth = 0)
        {
            if (depth == safeAfter)
                return;

            var remove = new List<TreeNode>();
            foreach (var node in root.Nodes.Cast<TreeNode>())
            {
                if (node.Nodes.Count == 0)
                {
                    remove.Add(node);
                }
                else
                {
                    Prune(node.WrapSingle(), safeAfter, depth + 1);
                }
            }

            foreach (var treeNode in remove)
            {
                root.Nodes.Remove(treeNode);
            }
        }

        public static void BundleConnectionString(this ITreeWrapper parent, int img, ConnectionString connectionString)
        {
            var conn = parent.Nodes.Add(connectionString.Id.ToString(), connectionString.Name, img, img);
            conn.Nodes.Add("value", "Value: " + connectionString.Value);
            conn.Nodes.Add("type", "Server Type: " + connectionString.ServerType);
        }

        public static void BundleCredential(this ITreeWrapper parent, int img, Credential credential)
        {
            var conn = parent.Nodes.Add(credential.Id.ToString(), credential.Name, img, img);
            conn.Nodes.Add("username", "Username: " + credential.Username);
            conn.Nodes.Add("domain", "Domain: " + credential.Domain);
            conn.Nodes.Add("password", "Password: " + credential.Password);
        }

        public static void BundleScript(this ITreeWrapper parent, ImageListBuilder builder, Script script)
        {
            int icon;
            builder.WithExtensionIcon(Path.GetExtension(script.Name), out icon);

            var node = parent.Nodes.Add(script.Id.ToString(), script.Name, icon, icon);

            var jobType = CoreRuntime.GetRegisteredType(script.JobTypeGuid);
            if (jobType == null)
                node.Nodes.Add("jobType", "Unknown Job Type");
            else
                node.Nodes.Add("jobType", "Job Type: " + jobType.Name);

            node.Nodes.Add("scriptLength", "Script Length: " + script.ScriptSource.Length + " Characters");
            node.Nodes.Add("treeDirectory", "Tree Directory: " + script.TreeDirectory);
        }

        public static void BundleAssembly(this ITreeWrapper parent, int img, ReferenceAssemblyInfo assembly)
        {
            var node = parent.Nodes.Add(assembly.Id.ToString(), assembly.Name, img, img);
            node.Nodes.Add("fullname", "Full Name: " + assembly.FullName);
            node.Nodes.Add("version", "Version: " + assembly.Version);
            node.Nodes.Add("size", "Size: " + assembly.Linked.Data.Length + " bytes");
        }
    }
}