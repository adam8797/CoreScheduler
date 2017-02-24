using System;
using CoreScheduler.Server;
using CoreScheduler.Server.Options;
using CoreScheduler.Server.Utilities;
using Quartz;
using Quartz.Impl;

namespace CoreScheduler.Client.Desktop.Utilities
{
    public class JobDetailsProxyObject
    {
        private readonly JobDetailImpl _source;

        public JobDetailsProxyObject(JobDetailImpl source)
        {
            _source = source;
            var info = new JobTypeInfo(source.JobType);
            Options = (JobOptions)_source.JobDataMap.Unpack(info.JobOptionsType);
        }

        public JobDetailImpl Unwrap()
        {
            _source.JobDataMap.Clear();
            _source.JobDataMap.Pack(Options);
            return _source;
        }

        public JobOptions Options { get; private set; }

        public string Description
        {
            get { return _source.Description; }
            set { _source.Description = value; }
        }

        #region Read Only

        public JobBuilder GetJobBuilder()
        {
            return _source.GetJobBuilder();
        }

        public JobKey Key
        {
            get { return _source.Key; }
        }

        public Type JobType
        {
            get { return _source.JobType; }
        }

        public bool Durable
        {
            get { return _source.Durable; }
        }

        public bool PersistJobDataAfterExecution
        {
            get { return _source.PersistJobDataAfterExecution; }
        }

        public bool ConcurrentExecutionDisallowed
        {
            get { return _source.ConcurrentExecutionDisallowed; }
        }

        public bool RequestsRecovery
        {
            get { return _source.RequestsRecovery; }
        }

        public object Clone()
        {
            return _source.Clone();
        }
        #endregion


    }
}
