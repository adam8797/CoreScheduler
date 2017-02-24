using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using CoreScheduler.Server.Attributes;
using CoreScheduler.Server.Utilities;
using Quartz;
using Quartz.Impl;
using EasyScintilla.Stylers;

namespace CoreScheduler.Client.Desktop.Utilities
{
    public static class Util
    {
        public static JobDetailsProxyObject Wrap(this IJobDetail detail)
        {
            return new JobDetailsProxyObject((JobDetailImpl)detail);
        }

        public static void OpenMessageBox(this Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static ScintillaStyler LoadStyler(this Type t)
        {
            if (t.HasAttribute<ScintillaStylerAttribute>())
            {
                Assembly asm;
                var attr = t.GetAttribute<ScintillaStylerAttribute>();

                if (string.IsNullOrEmpty(attr.Assembly))
                    asm = Assembly.GetAssembly(typeof(ScintillaStyler));
                else
                    asm = Assembly.Load(attr.Assembly);

                var style = asm.GetType(attr.Name);
                if (style == null)
                    return null;
                var inst = Activator.CreateInstance(style);
                return inst as ScintillaStyler;
            }
            return null;
        }

        public static IEnumerable<TreeNode> Descendants(this TreeNodeCollection c)
        {
            foreach (var node in c.OfType<TreeNode>())
            {
                yield return node;

                foreach (var descendant in node.Nodes.Descendants())
                {
                    yield return descendant;
                }
            }
        }

        public static void Replace(this Control old, Control replacement)
        {
            replacement.Location = old.Location;
            replacement.Size = old.Size;

            old.Parent.Controls.Add(replacement);
            old.Parent.Controls.Remove(old);
            old.Dispose();
        }

        public static void SearchAndExpandAllUnder(this TreeNode node, string name)
        {
            if (node.Name == name)
                node.ExpandAll();
            else
            {
                foreach (var subNode in node.Nodes.Cast<TreeNode>())
                {
                    SearchAndExpandAllUnder(subNode, name);
                }
            }
        }

        public static IEnumerable<T> If<T>(this IEnumerable<T> source, bool branch)
        {
            return branch ? source : Enumerable.Empty<T>();
        }

        public static IEnumerable<T> Merge<T>(this IEnumerable<T> source, IEnumerable<T> addition, Func<T, T, bool> equalFunc)
        {
            return source.Concat(addition).Distinct(new DynamicComparer<T>(equalFunc));
        }

        public static IEnumerable<T> Merge<T>(this IEnumerable<T> source, IEnumerable<T> addition) where T : IGuidId
        {
            return source.Merge(addition, (x, y) => x.Id == y.Id);
        }

        public class DynamicComparer<T> : IEqualityComparer<T>
        {
            private readonly Func<T, T, bool> _equals;

            public DynamicComparer(Func<T, T, bool> equals)
            {
                _equals = @equals;
            }

            public bool Equals(T x, T y)
            {
                return _equals(x, y);
            }

            public int GetHashCode(T obj)
            {
                return 1;
            }
        }
    }
}
