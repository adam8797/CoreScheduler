using System.ComponentModel;
using CoreScheduler.Server.Attributes;

namespace CoreScheduler.Server.Options
{
    [Packable]
    public class JobOptions : Component
    {
        public string ConsoleStreaming { get; set; }
        public string EmailOnFinish { get; set; }
    }
}
