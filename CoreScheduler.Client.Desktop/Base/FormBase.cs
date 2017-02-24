using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoreScheduler.Client.Desktop.Controls;
using CoreScheduler.Client.Desktop.Forms;
using CoreScheduler.Client.Desktop.Utilities;
using CoreScheduler.Server.Database;
using CoreScheduler.Server.Utilities;

namespace CoreScheduler.Client.Desktop.Base
{
    public partial class FormBase : Form
    {
        //Delay in ms that will be used on every Await call. This is to allow WinForms to draw any changes.
        private const int AwaitDelay = 250;

        private DatabaseContext _database;
        
        public FormBase()
        {
            InitializeComponent();
        }

        protected DatabaseContext Database
        {
            get { return _database ?? (_database = new DatabaseContext()); }
            set { _database = value; }
        }

        protected void Open<T>() where T : FormBase, new()
        {
            Open(new T());
        }

        protected void Open(FormBase f)
        {
            f.MdiParent = MdiParent;
            f._parent = this;
            f.Show();
        }

        private FormBase _parent;


        protected async Task ReloadParent()
        {
            if (_parent != null)
                await _parent.Reload();
        }

        protected virtual async Task Reload()
        {
            
        }

        private const string AwaitingState = "Working...";
        private const string ReadyState = "Ready";
        
        protected async Task<T> Await<T>(Func<Task<T>> action)
        {
            DisableForm();
            ((RootForm)MdiParent).StartLoading();
            ((RootForm)MdiParent).SetStatus(AwaitingState);

            await Task.Delay(AwaitDelay);
            var ret = await action();

            EnableForm();
            ((RootForm)MdiParent).StopLoading();
            ((RootForm)MdiParent).SetStatus(ReadyState);
            return ret;
        }

        protected async Task<T> Await<T>(Task<T> task)
        {
            DisableForm();
            ((RootForm)MdiParent).StartLoading();
            ((RootForm)MdiParent).SetStatus(AwaitingState);

            await Task.Delay(AwaitDelay);
            var ret = await task;

            EnableForm();
            ((RootForm)MdiParent).StopLoading();
            ((RootForm)MdiParent).SetStatus(ReadyState);

            return ret;
        }

        protected async Task Await(Func<Task> action)
        {
            DisableForm();
            ((RootForm)MdiParent).StartLoading();
            ((RootForm)MdiParent).SetStatus(AwaitingState);

            await Task.Delay(AwaitDelay);
            await action();

            EnableForm();
            ((RootForm)MdiParent).StopLoading();
            ((RootForm)MdiParent).SetStatus(ReadyState);
        }

        protected async Task Await(Task task)
        {
            DisableForm();
            ((RootForm)MdiParent).StartLoading();
            ((RootForm)MdiParent).SetStatus(AwaitingState);

            await Task.Delay(AwaitDelay);
            await task;

            EnableForm();
            ((RootForm)MdiParent).StopLoading();
            ((RootForm)MdiParent).SetStatus(ReadyState);
        }

        protected void DisableForm(params Control[] exclude)
        {
            UseWaitCursor = true;
            foreach (Control fControl in Controls.Cast<Control>().Where(x => !exclude.Contains(x)))
            {
                fControl.Enabled = false;
            }
        }

        protected void EnableForm(params Control[] exclude)
        {
            UseWaitCursor = false;
            foreach (Control fControl in Controls.Cast<Control>().Where(x => !exclude.Contains(x)))
            {
                fControl.Enabled = true;
            }
        }

        protected void EnableGroup(params Control[] controls)
        {
            foreach (var control in controls)
            {
                control.Enabled = true;
            }
        }

        protected void DisableGroup(params Control[] controls)
        {
            foreach (var control in controls)
            {
                control.Enabled = false;
            }
        }

        protected Control GetEditor(Type t)
        {
            var asm = Assembly.GetCallingAssembly();

            var controlType = asm
                .GetTypes()
                .FirstOrDefault(x => x.HasAttribute<EditorForJobTypeAttribute>() &&
                                     x.GetAttribute<EditorForJobTypeAttribute>().JobType == t);

            if (controlType == null)
                controlType = asm
                    .GetTypes()
                    .FirstOrDefault(x => x.HasAttribute<EditorForJobTypeAttribute>() &&
                                         x.GetAttribute<EditorForJobTypeAttribute>().JobType.IsAssignableFrom(t));

            if (controlType == null)
                controlType = typeof(JobOptionsControl);

            var control = Activator.CreateInstance(controlType) as Control;

            return control;
        }

        protected void TreeMouseFix(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                ((TreeView) sender).SelectedNode = e.Node;
        }

    }
}
