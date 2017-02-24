using System;
using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using CoreScheduler.Server.Attributes;
using CoreScheduler.Server.Service;
using Quartz;
using Quartz.Impl;

namespace CoreScheduler.Server
{
    public class CoreRuntime
    {
        private static readonly ILog Logger;
        public static IScheduler Scheduler { get; private set; }

        static CoreRuntime()
        {
            // Create the scheduler factory
            ISchedulerFactory factory = new StdSchedulerFactory();
            Scheduler = factory.GetScheduler();

            // Create the logger
            Logger = LogManager.GetLogger<CoreRuntime>();

            // Run Job Auto-discover
            AutoDiscover();
        }

        public static void Start()
        {
            try
            {
                Scheduler.Start();
                ServiceManager.Start();
            }
            catch (Exception ex)
            {
                Logger.Fatal(string.Format("Scheduler start failed: {0}", ex.Message), ex);
                throw;
            }

            Logger.Info("Scheduler started successfully");
        }

        public static void Stop()
        {
            try
            {
                Scheduler.Shutdown(true);
            }
            catch (Exception ex)
            {
                Logger.Error(string.Format("Scheduler stop failed: {0}", ex.Message), ex);
                throw;
            }

            Logger.Info("Scheduler shutdown complete");
        }

        public static void Pause()
        {
            Scheduler.PauseAll();
        }

        public static void Resume()
        {
            Scheduler.ResumeAll();
        }

        private static List<JobTypeInfo> _registeredTypes;

        private static void AutoDiscover()
        {
            var classes =
                AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(
                        x =>
                            x.GetTypes()
                                .Where(y => Attribute.IsDefined(y, typeof(AutoDiscoverAttribute))));

            foreach (var jobType in classes)
            {
                RegisterJobType(jobType);
            }
        }

        public static void RegisterJobType(Type t)
        {
            if (_registeredTypes == null)
                _registeredTypes = new List<JobTypeInfo>();

            var jt = new JobTypeInfo(t);

            _registeredTypes.Add(jt);

            Logger.InfoFormat("Registered Job Type ID {0} ({1})", jt.JobType.GUID, jt.Name);
            Logger.InfoFormat("    With Options Type {0}", jt.JobOptionsType.FullName);
            Logger.InfoFormat("    With Extension {0}", jt.SourceFileExtension);
            if (!string.IsNullOrEmpty(jt.Category))
                Logger.InfoFormat("    With Category {0}", jt.Category);
        }

        public static void RegisterJobType<T>()
        {
            RegisterJobType(typeof(T));
        }

        public static List<JobTypeInfo> GetRegisteredTypes()
        {
            return _registeredTypes;
        }

        public static JobTypeInfo GetRegisteredType(Guid id)
        {
            return _registeredTypes.SingleOrDefault(x => x.Guid == id);
        }
    }
}
