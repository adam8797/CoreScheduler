using System;
using CoreScheduler.Api;
using CoreScheduler.Server.Database;
using CoreScheduler.Server.Jobs;
using CoreScheduler.Server.Options;

namespace CoreScheduler.Server.ApiImpl
{
    public class EventManager<TConfig> : MarshalByRefObject, IEventManager where TConfig: JobOptions, new()
    {
        private readonly Job<TConfig> _parent;
        private readonly JobEvent _parentEvent;

        public EventManager(Job<TConfig> parent, JobEvent parentEvent)
        {
            _parent = parent;
            _parentEvent = parentEvent;
        }

        public void Add(EventLevel level, string message)
        {
            _parent.BroadcastLog(level, _parentEvent, "Exe", message);
        }

        public void Add(EventLevel level, string format, params object[] args)
        {
            Add(level, string.Format(format, args));
        }
    }
}
