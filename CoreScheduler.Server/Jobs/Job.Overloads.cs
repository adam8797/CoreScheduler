using System;
using CoreScheduler.Api;
using CoreScheduler.Server.Database;
using Quartz;

namespace CoreScheduler.Server.Jobs
{
    public partial class Job<TConfig>
    {
        #region BroadcastLog()

        internal JobEvent BroadcastLog(EventLevel level, string message)
        {
            return BroadcastLog(level, null, DefaultEventSource, message);
        }

        internal JobEvent BroadcastLog(EventLevel level, string format, params object[] args)
        {
            return BroadcastLog(level, null, DefaultEventSource, string.Format(format, args));
        }

        internal JobEvent BroadcastLog(EventLevel level, JobEvent parent, string message)
        {
            return BroadcastLog(level, parent, DefaultEventSource, message);
        }

        internal JobEvent BroadcastLog(EventLevel level, JobEvent parent, string format, params object[] args)
        {
            return BroadcastLog(level, null, DefaultEventSource, string.Format(format, args));
        }

        internal JobEvent BroadcastLog(EventLevel level, string from, string message)
        {
            return BroadcastLog(level, null, from, message);
        }

        internal JobEvent BroadcastLog(EventLevel level, string from, string format, params object[] args)
        {
            return BroadcastLog(level, null, from, string.Format(format, args));
        }

        internal JobEvent BroadcastLog(EventLevel level, JobEvent parent, string from, string format,
            params object[] args)
        {
            return BroadcastLog(level, parent, from, string.Format(format, args));
        }

        #endregion


        internal JobEvent AddEvent(IJobExecutionContext context, Guid runId, EventLevel level, string format, params object[] args)
        {
            return AddEvent(context, runId, level, string.Format(format, args));
        }

        internal JobEvent AddEvent(IJobExecutionContext context, Guid runId, JobEvent parent, EventLevel level, string format, params object[] args)
        {
            return AddEvent(context, runId, level, string.Format(format, args));
        }

        protected JobEvent AddEvent(JobEvent parent, EventLevel level, string message)
        {
            return AddEvent(Context, RunId, parent, level, message);
        }

        protected JobEvent AddEvent(JobEvent parent, EventLevel level, string format, params object[] args)
        {
            return AddEvent(parent, level, string.Format(format, args));
        }

        protected JobEvent AddEvent(EventLevel level, string message)
        {
            return AddEvent(Context, RunId, level, message);
        }

        protected JobEvent AddEvent(EventLevel level, string format, params object[] args)
        {
            return AddEvent(level, string.Format(format, args));
        }
    }
}
