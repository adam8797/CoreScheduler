using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CoreScheduler.Server;
using Quartz;
using Quartz.Impl.Matchers;
using Quartz.Spi;

namespace CoreScheduler.Client.Desktop.Utilities
{
    public static class CoreSchedulerProxy
    {
        private static T Try<T>(Func<T> func)
        {
            try
            {
                return func();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was a problem communicating with Quartz.\n\n" + ex.Message + "\n\nThe application will now close");
                Environment.Exit(1);
                throw;
            }
        }

        private static void Try(Action act)
        {
            try
            {
                act();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was a problem communicating with Quartz.\n\n" + ex.Message + "\n\nThe application will now close");
                Environment.Exit(1);
            }
        }

        public static bool IsJobGroupPaused(string groupName)
        {
            return Try(() => CoreRuntime.Scheduler.IsJobGroupPaused(groupName));
        }

        public static bool IsTriggerGroupPaused(string groupName)
        {
            return Try(() => CoreRuntime.Scheduler.IsTriggerGroupPaused(groupName));
        }

        public static SchedulerMetaData GetMetaData()
        {
            return Try(() => CoreRuntime.Scheduler.GetMetaData());
        }

        public static IList<IJobExecutionContext> GetCurrentlyExecutingJobs()
        {
            return Try(() => CoreRuntime.Scheduler.GetCurrentlyExecutingJobs());
        }

        public static IList<string> GetJobGroupNames()
        {
            return Try(() => CoreRuntime.Scheduler.GetJobGroupNames());
        }

        public static IList<string> GetTriggerGroupNames()
        {
            return Try(() => CoreRuntime.Scheduler.GetTriggerGroupNames());
        }

        public static Quartz.Collection.ISet<string> GetPausedTriggerGroups()
        {
            return Try(() => CoreRuntime.Scheduler.GetPausedTriggerGroups());
        }

        public static void Start()
        {
            Try(() => CoreRuntime.Scheduler.Start());
        }

        public static void StartDelayed(TimeSpan delay)
        {
            Try(() => CoreRuntime.Scheduler.StartDelayed(delay));
        }

        public static void Standby()
        {
            Try(() => CoreRuntime.Scheduler.Standby());
        }

        public static void Shutdown()
        {
            Try(() => CoreRuntime.Scheduler.Shutdown());
        }

        public static void Shutdown(bool waitForJobsToComplete)
        {
            Try(() => CoreRuntime.Scheduler.Shutdown(waitForJobsToComplete));
        }

        public static DateTimeOffset ScheduleJob(IJobDetail jobDetail, ITrigger trigger)
        {
            return Try(() => CoreRuntime.Scheduler.ScheduleJob(jobDetail, trigger));
        }

        public static DateTimeOffset ScheduleJob(ITrigger trigger)
        {
            return Try(() => CoreRuntime.Scheduler.ScheduleJob(trigger));
        }

        public static void ScheduleJobs(IDictionary<IJobDetail, Quartz.Collection.ISet<ITrigger>> triggersAndJobs, bool replace)
        {
            Try(() => CoreRuntime.Scheduler.ScheduleJobs(triggersAndJobs, replace));
        }

        public static void ScheduleJob(IJobDetail jobDetail, Quartz.Collection.ISet<ITrigger> triggersForJob, bool replace)
        {
            Try(() => CoreRuntime.Scheduler.ScheduleJob(jobDetail, triggersForJob, replace));
        }

        public static bool UnscheduleJob(TriggerKey triggerKey)
        {
            return Try(() => CoreRuntime.Scheduler.UnscheduleJob(triggerKey));
        }

        public static bool UnscheduleJobs(IList<TriggerKey> triggerKeys)
        {
            return Try(() => CoreRuntime.Scheduler.UnscheduleJobs(triggerKeys));
        }

        public static DateTimeOffset? RescheduleJob(TriggerKey triggerKey, ITrigger newTrigger)
        {
            return Try(() => CoreRuntime.Scheduler.RescheduleJob(triggerKey, newTrigger));
        }

        public static void AddJob(IJobDetail jobDetail, bool replace)
        {
            Try(() => CoreRuntime.Scheduler.AddJob(jobDetail, replace));
        }

        public static void AddJob(IJobDetail jobDetail, bool replace, bool storeNonDurableWhileAwaitingScheduling)
        {
            Try(() => CoreRuntime.Scheduler.AddJob(jobDetail, replace, storeNonDurableWhileAwaitingScheduling));
        }

        public static bool DeleteJob(JobKey jobKey)
        {
            return Try(() => CoreRuntime.Scheduler.DeleteJob(jobKey));
        }

        public static bool DeleteJobs(IList<JobKey> jobKeys)
        {
            return Try(() => CoreRuntime.Scheduler.DeleteJobs(jobKeys));
        }

        public static void TriggerJob(JobKey jobKey)
        {
            Try(() => CoreRuntime.Scheduler.TriggerJob(jobKey));
        }

        public static void TriggerJob(JobKey jobKey, JobDataMap data)
        {
            Try(() => CoreRuntime.Scheduler.TriggerJob(jobKey, data));
        }

        public static void PauseJob(JobKey jobKey)
        {
            Try(() => CoreRuntime.Scheduler.PauseJob(jobKey));
        }

        public static void PauseJobs(GroupMatcher<JobKey> matcher)
        {
            Try(() => CoreRuntime.Scheduler.PauseJobs(matcher));
        }

        public static void PauseTrigger(TriggerKey triggerKey)
        {
            Try(() => CoreRuntime.Scheduler.PauseTrigger(triggerKey));
        }

        public static void PauseTriggers(GroupMatcher<TriggerKey> matcher)
        {
            Try(() => CoreRuntime.Scheduler.PauseTriggers(matcher));
        }

        public static void ResumeJob(JobKey jobKey)
        {
            Try(() => CoreRuntime.Scheduler.ResumeJob(jobKey));
        }

        public static void ResumeJobs(GroupMatcher<JobKey> matcher)
        {
            Try(() => CoreRuntime.Scheduler.ResumeJobs(matcher));
        }

        public static void ResumeTrigger(TriggerKey triggerKey)
        {
            Try(() => CoreRuntime.Scheduler.ResumeTrigger(triggerKey));
        }

        public static void ResumeTriggers(GroupMatcher<TriggerKey> matcher)
        {
            Try(() => CoreRuntime.Scheduler.ResumeTriggers(matcher));
        }

        public static void PauseAll()
        {
            Try(() => CoreRuntime.Scheduler.PauseAll());
        }

        public static void ResumeAll()
        {
            Try(() => CoreRuntime.Scheduler.ResumeAll());
        }

        public static Quartz.Collection.ISet<JobKey> GetJobKeys(GroupMatcher<JobKey> matcher)
        {
            return Try(() => CoreRuntime.Scheduler.GetJobKeys(matcher));
        }

        public static IList<ITrigger> GetTriggersOfJob(JobKey jobKey)
        {
            return Try(() => CoreRuntime.Scheduler.GetTriggersOfJob(jobKey));
        }

        public static Quartz.Collection.ISet<TriggerKey> GetTriggerKeys(GroupMatcher<TriggerKey> matcher)
        {
            return Try(() => CoreRuntime.Scheduler.GetTriggerKeys(matcher));
        }

        public static IJobDetail GetJobDetail(JobKey jobKey)
        {
            return Try(() => CoreRuntime.Scheduler.GetJobDetail(jobKey));
        }

        public static ITrigger GetTrigger(TriggerKey triggerKey)
        {
            return Try(() => CoreRuntime.Scheduler.GetTrigger(triggerKey));
        }

        public static TriggerState GetTriggerState(TriggerKey triggerKey)
        {
            return Try(() => CoreRuntime.Scheduler.GetTriggerState(triggerKey));
        }

        public static void AddCalendar(string calName, ICalendar calendar, bool replace, bool updateTriggers)
        {
            Try(() => CoreRuntime.Scheduler.AddCalendar(calName, calendar, replace, updateTriggers));
        }

        public static bool DeleteCalendar(string calName)
        {
            return Try(() => CoreRuntime.Scheduler.DeleteCalendar(calName));
        }

        public static ICalendar GetCalendar(string calName)
        {
            return Try(() => CoreRuntime.Scheduler.GetCalendar(calName));
        }

        public static IList<string> GetCalendarNames()
        {
            return Try(() => CoreRuntime.Scheduler.GetCalendarNames());
        }

        public static bool Interrupt(JobKey jobKey)
        {
            return Try(() => CoreRuntime.Scheduler.Interrupt(jobKey));
        }

        public static bool Interrupt(string fireInstanceId)
        {
            return Try(() => CoreRuntime.Scheduler.Interrupt(fireInstanceId));
        }

        public static bool CheckExists(JobKey jobKey)
        {
            return Try(() => CoreRuntime.Scheduler.CheckExists(jobKey));
        }

        public static bool CheckExists(TriggerKey triggerKey)
        {
            return Try(() => CoreRuntime.Scheduler.CheckExists(triggerKey));
        }

        public static void Clear()
        {
            Try(() => CoreRuntime.Scheduler.Clear());
        }

        public static string SchedulerName
        {
            get { return Try(() => CoreRuntime.Scheduler.SchedulerName); }
        }

        public static string SchedulerInstanceId
        {
            get { return Try(() => CoreRuntime.Scheduler.SchedulerInstanceId); }
        }

        public static SchedulerContext Context
        {
            get { return Try(() => CoreRuntime.Scheduler.Context); }
        }

        public static bool InStandbyMode
        {
            get { return Try(() => CoreRuntime.Scheduler.InStandbyMode); }
        }

        public static bool IsShutdown
        {
            get { return Try(() => CoreRuntime.Scheduler.IsShutdown); }
        }

        public static IJobFactory JobFactory
        {
            set { Try(() => CoreRuntime.Scheduler.JobFactory = value); }
        }

        public static IListenerManager ListenerManager
        {
            get { return Try(() => CoreRuntime.Scheduler.ListenerManager); }
        }

        public static bool IsStarted
        {
            get { return Try(() => CoreRuntime.Scheduler.IsStarted); }
        }
    }
}
