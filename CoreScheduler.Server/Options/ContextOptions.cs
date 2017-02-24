using System.ComponentModel;
using CoreScheduler.Server.Attributes;

namespace CoreScheduler.Server.Options
{
    [Packable]
    public class ContextOptions : Component
    {
        public bool Enable { get; set; }
        public bool LoggerEnable { get; set; }
        public bool EventsEnable { get; set; }
        public string[] ConnectionStrings { get; set; }
        public string[] Credentials { get; set; }
    }
}
