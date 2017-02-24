using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using Quartz;

namespace CoreScheduler.Client.Desktop.Forms
{
    public partial class JobDataMapEditor : Form
    {
        private JobDataMap _value;

        public JobDataMap Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public JobDataMapEditor()
        {
            InitializeComponent();
        }


    }

    public class JobDataMapTypeEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            var svc = provider.GetService(typeof(IWindowsFormsEditorService)) as IWindowsFormsEditorService;

            var dataMap = value as JobDataMap;

            if (svc != null && dataMap != null)
            {
                using (var form = new JobDataMapEditor())
                {
                    form.Value = dataMap;
                    if (svc.ShowDialog(form) == DialogResult.OK)
                    {
                        dataMap = form.Value;
                    }
                }
            }

            return dataMap;
        }
    }
}
