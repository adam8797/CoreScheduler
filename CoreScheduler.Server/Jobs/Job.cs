using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Common.Logging;
using CoreScheduler.Api;
using CoreScheduler.Server.Database;
using CoreScheduler.Server.Options;
using CoreScheduler.Server.Service.Impl;
using CoreScheduler.Server.Utilities;
using Quartz;

namespace CoreScheduler.Server.Jobs
{
    public abstract class Job : Job<JobOptions>
    {
    }

    public abstract partial class Job<TConfig> : IJob where TConfig : JobOptions, new()
    {
        private const string DefaultEventSource = "Job";
        private const string ExecutionDirectory = "Execution";

        #region Private Fields

        private TcpClient _consoleRedirectionClient;

        #endregion

        #region Protected Properties

        protected IJobExecutionContext Context { get; private set; }
        protected ILog Log { get; private set; }
        protected TConfig Config { get; private set; }
        protected DatabaseContext Database { get; private set; }
        protected Guid RunId { get; private set; }
        protected List<JobEvent> Events { get; private set; }
        protected SmtpClient EmailClient { get; private set; }

#if DEBUG
        protected bool Debug = true;
#else
        protected bool Debug = false;
#endif

        #endregion

        #region Protected Methods

        #region Console Redirection

        protected void Redirect(string message)
        {
            if (_consoleRedirectionClient.Connected)
            {
                var bytes = Encoding.UTF8.GetBytes(message);
                _consoleRedirectionClient.GetStream().Write(bytes, 0, bytes.Length);
            }
        }

        protected void RedirectLine(string message)
        {
            Redirect(message + "\r\n");
        }

        protected Stream GetRedirectedStream()
        {
            if (_consoleRedirectionClient.Connected)
                return _consoleRedirectionClient.GetStream();
            return Stream.Null;
        }

        #endregion

        protected TOptions GetConfig<TOptions>() where TOptions : JobOptions, new()
        {
            return Context.MergedJobDataMap.Unpack<TOptions>();
        }

        protected virtual string GetExecutionDirectory()
        {
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), ExecutionDirectory,
                RunId.ToString("D"));

            if (Directory.Exists(path))
                return path;

            var d = Directory.CreateDirectory(path);

            return d.FullName;
        }

        #endregion

        #region Internal Methods

        internal JobEvent BroadcastLog(EventLevel level, JobEvent parent, string from, string message)
        {
            string levelString = "";
            if (string.IsNullOrEmpty(message))
                return null;

            switch (level)
            {
                case EventLevel.Debug:
                    Log.Debug(message);
                    levelString = "  [DEBUG]";
                    break;
                case EventLevel.Success:
                    Log.Info(message);
                    levelString = "[SUCCESS]";
                    break;
                case EventLevel.Warning:
                    Log.Warn(message);
                    levelString = "[WARNING]";
                    break;
                case EventLevel.Error:
                    Log.Error(message);
                    levelString = "  [ERROR]";
                    break;
                case EventLevel.Fatal:
                    Log.Fatal(message);
                    levelString = "  [FATAL]";
                    break;
                default:
                    Log.Info(message);
                    levelString = "   [INFO]";
                    break;
            }

            RedirectLine(string.Format("[{0}] {1} {2}", from, levelString, message));

            if (parent != null)
                return AddEvent(parent, level, message);
            return AddEvent(level, message);
        }

        internal JobEvent AddEvent(IJobExecutionContext context, Guid runId, EventLevel level, string message)
        {
            var e = new JobEvent()
            {
                EventLevel = level,
                JobId = context.JobDetail.Key.Name,
                RunId = runId,
                Message = message,
                RunOrder = Events.Count
            };
            Events.Add(e);
            return e;
        }

        internal JobEvent AddEvent(IJobExecutionContext context, Guid runId, JobEvent parent, EventLevel level, string message)
        {
            var e = new JobEvent()
            {
                EventLevel = level,
                JobId = context.JobDetail.Key.Name,
                RunId = runId,
                Message = message,
                ParentId = parent.Id,
                Parent = parent,
                RunOrder = Events.Count
            };
            parent.Children.Add(e);
            Events.Add(e);
            return e;
        }

        internal void SaveEvents()
        {
            Database.Events.AddRange(Events);
            Events.Clear();
            Database.SaveChanges();
        }

        #endregion

        public async void Execute(IJobExecutionContext context)
        {
            //Build all protected props
            Context = context;
            Log = LogManager.GetLogger(GetType());
            Config = GetConfig<TConfig>();
            Database = new DatabaseContext();
            RunId = Guid.NewGuid();
            Events = new List<JobEvent>();
            //ToDo: smtp configuration
            EmailClient = new SmtpClient();

            //Setup console redirection
            _consoleRedirectionClient = new TcpClient();

            try
            {
                if (!string.IsNullOrEmpty(Config.ConsoleStreaming))
                {
                    var streamId = Config.ConsoleStreaming;
                    var request =
                        SchedulerExtensionService.RegisteredClients.ToArray().SingleOrDefault(x => x.Id == streamId);

                    if (request == null)
                        return;

                    try
                    {
                        Log.DebugFormat("Attempting to connect to {0}:{1}", request.Address, request.Port);
                        _consoleRedirectionClient.Connect(request.Address, request.Port);
                    }
                    catch (SocketException ex)
                    {
                        Log.ErrorFormat("Error connecting to {0}:{1}. Job will continue.", request.Address, request.Port);
                    }
                    RedirectLine("Beginning stream of run id: " + RunId + "...");
                }

                // Run the setup
                await Setup();

                // Run the job
                await Run();

                BroadcastLog(EventLevel.Success, "Job Exited Successfully - Job ID: {0};", context.JobDetail.Key);
            }
            catch (Exception ex)
            {
                var p = BroadcastLog(EventLevel.Fatal, "Fatal error processing Job [{0}] -  Job ID: {1};", GetType().Name,
                    context.JobDetail.Key);
                BroadcastLog(EventLevel.Fatal, p, ex.ToString());
            }
            finally
            {
                Cleanup();
                Redirect("__CORE_END_STREAM__");
                _consoleRedirectionClient.Close();

                if (!string.IsNullOrEmpty(Config.EmailOnFinish))
                {
                    //ToDo: Email Configuration
                    var message = new MailMessage("noreply@example.com", Config.EmailOnFinish, "Job Finished", BuildMessageBody());
                    message.IsBodyHtml = true;
                    EmailClient.Send(message);
                }

                SaveEvents();
            }
        }

        #region Email Support

        private string BuildMessageBody()
        {
            var builder = new StringBuilder();
            builder.AppendLine("Job has finished");
            builder.AppendLine();
            builder.AppendLine("<dl>");
            builder.AppendLine("</dl>");
            builder.AppendLine();
            builder.AppendLine(TraverseEvents(Events));
            return builder.ToString();
        }

        private string TraverseEvents(IEnumerable<JobEvent> events)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("<ul>");
            foreach (var jobEvent in events.Where(x => x.ParentId == Guid.Empty))
            {
                if (!jobEvent.Children.Any())
                    builder.AppendFormat("<li>[{0}] {1:h:mm:ss.fff tt} - {2}</li>", jobEvent.EventLevel,
                        jobEvent.Timestamp, jobEvent.Message);
                else
                {
                    builder.AppendFormat("<li>[{0}] {1:h:mm:ss.fff tt} - {2}", jobEvent.EventLevel, jobEvent.Timestamp, jobEvent.Message);
                    builder.AppendLine(TraverseEvents(jobEvent.Children));
                    builder.AppendLine("</li>");
                }
            }
            builder.AppendLine("</ul>");
            return builder.ToString();
        }
        #endregion

        #region Virtual Methods

        /// <summary>
        /// Called in the finally block of the Execute method. Used for deleting extra files.
        /// </summary>
        protected virtual void Cleanup()
        {
            Directory.Delete(GetExecutionDirectory(), true);
        }

        #endregion

        #region Abstract Methods

        /// <summary>
        /// Function is called once in the lifetime of a job. This is where you do all of the specific job work.
        /// </summary>
        protected abstract Task Run();

        /// <summary>
        /// Function is called once, right before Run() is called.
        /// </summary>
        protected abstract Task Setup();

        #endregion
        
    }
}
