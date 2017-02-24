using Quartz;

namespace CoreScheduler.Client.Desktop.Controls
{
    public partial class LargeTriggerEditor : TriggerEditor
    {
        public LargeTriggerEditor()
        {
            InitializeComponent();
        }

        public LargeTriggerEditor(ICronTrigger trigger) : base(trigger)
        {
            InitializeComponent();
        }
            
    }
}
