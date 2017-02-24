using System.Drawing;
using System.Windows.Forms;
using CoreScheduler.Server.Options;

namespace CoreScheduler.Client.Desktop.Controls
{
    public class JobOptionsControl : UserControl
    {
        private bool _useMinimumSize;

        public bool UseMinimumSize
        {
            get { return _useMinimumSize; }
            set
            {
                if (value)
                    MinimumSize = new Size(790, 328);
                else
                    MinimumSize = new Size(0, 0);

                _useMinimumSize = value;
            }
        }

        public JobOptionsControl()
        {
            UseMinimumSize = true;
        }

        public virtual JobOptions BuildOptions(JobOptions options)
        {
            return options;
        }
    }
}
