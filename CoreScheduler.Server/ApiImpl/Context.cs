using System;
using System.Collections.Generic;
using System.Net.Mail;
using Common.Logging;
using CoreScheduler.Api;
using CoreScheduler.Server.Database;
using CoreScheduler.Server.Jobs;
using CoreScheduler.Server.Options;
using Quartz;

namespace CoreScheduler.Server.ApiImpl
{
    public class Context<TConfig> : MarshalByRefObject, IContext where TConfig : JobOptions, new()
    {
        public Context(ContextOptions contextOptions, IJobExecutionContext jobContext, JobEvent parent, Guid runId, Job<TConfig> host)
        {
            Log = LogManager.GetLogger(jobContext.JobDetail.JobType.Name + ":" + jobContext.JobDetail.Description);
            Events = new EventManager<TConfig>(host, parent);

            var db = new DatabaseContext();
            var creds = new Dictionary<string, ICredential>();
            foreach (var credId in contextOptions.Credentials)
            {
                Guid id;
                if (Guid.TryParse(credId, out id))
                {
                    var c = db.Credentials.Find(id);
                    if (c != null)
                        creds.Add(c.Name, c);
                }
            }

            var conns = new Dictionary<string, IConnectionString>();
            foreach (var contextOptionsConnectionString in contextOptions.ConnectionStrings)
            {
                Guid id;
                if (Guid.TryParse(contextOptionsConnectionString, out id))
                {
                    var c = db.ConnectionStrings.Find(id);
                    if (c != null)
                        conns.Add(c.Name, c);
                }
            }

            Credentials = new CredentialManager(creds);
            ConnectionStrings = new ConnectionStringManager(conns);

            SmtpClient = new SmtpClient("mail.example.com");
        }

        public ILog Log { get; set; }
        public IEventManager Events { get; set; }
        public ICredentialManager Credentials { get; set; }
        public IConnectionStringManager ConnectionStrings { get; set; }
        public SmtpClient SmtpClient { get; set; }
    }
}
