using CoreScheduler.Server.Attributes;

namespace CoreScheduler.Server.Options
{
    [Packable]
    public class ScriptJobOptions : JobOptions
    {
        public string ScriptId { get; set; }

        public string[] DllReferences { get; set; }
        public string[] ScriptReferences { get; set; }

        public ContextOptions Context { get; set; }
    }
}
