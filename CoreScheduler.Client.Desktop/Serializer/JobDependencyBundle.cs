using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreScheduler.Client.Desktop.Utilities;
using CoreScheduler.Server;
using CoreScheduler.Server.Database;
using CoreScheduler.Server.Options;
using CoreScheduler.Server.Utilities;
using Quartz;

namespace CoreScheduler.Client.Desktop.Serializer
{
    public class JobDependencyBundle
    {
        public List<SerializedJob> Jobs { get; set; }
        public List<ConnectionString> ConnectionStrings { get; set; }
        public List<Credential> Credentials { get; set; }
        public List<Script> Scripts { get; set; }
        public List<ReferenceAssemblyInfo> AssemblyInfo { get; set; }
        public List<ReferenceAssembly> AssemblyData { get; set; }

        public List<ReferenceAssemblyInfo> JoinAssemblies()
        {
            foreach (var referenceAssemblyInfo in AssemblyInfo)
            {
                referenceAssemblyInfo.Linked = AssemblyData.SingleOrDefault(x => x.Id == referenceAssemblyInfo.Id);
            }
            return AssemblyInfo;
        }

        public JobDependencyBundle()
        {
            ConnectionStrings = new List<ConnectionString>();
            Credentials = new List<Credential>();
            Scripts = new List<Script>();
            AssemblyInfo = new List<ReferenceAssemblyInfo>();
            AssemblyData = new List<ReferenceAssembly>();
            Jobs = new List<SerializedJob>();
        }

        public static async Task<JobDependencyBundle> Build(JobKey jobKey, JobTypeInfo info, JobOptions options)
        {
            var database = new DatabaseContext();
            var bundle = new JobDependencyBundle();

            var jobInfo = CoreSchedulerProxy.GetJobDetail(jobKey);

            bundle.Jobs.Add(new SerializedJob()
            {
                DataMap = jobInfo.JobDataMap.ToDictionary(x => x.Key, x => x.Value),
                Name = jobInfo.Description,
                JobType = info.Guid,
                Triggers = CoreSchedulerProxy.GetTriggersOfJob(jobKey).Select(x => new SerializedTrigger()
                {
                    Cron = ((ICronTrigger)x).CronExpressionString,
                    Missfire = x.MisfireInstruction.ToString(),
                    Name = x.Description,
                    StartTime = x.StartTimeUtc.DateTime
                }).ToList(),
            });

            if (options is ScriptJobOptions)
            {
                var sjo = (ScriptJobOptions)options;

                bundle.Scripts.Add(await database.Scripts.FindAsync(new Guid(sjo.ScriptId)));

                foreach (var x in sjo.ScriptReferences)
                {
                    bundle.Scripts.Add(await database.Scripts.FindAsync(new Guid(x)));
                }

                foreach (var x in sjo.DllReferences)
                {
                    bundle.AssemblyInfo.Add(await database.AssemblyInfo.FindAsync(new Guid(x)));
                    bundle.AssemblyData.Add(await database.Assemblies.FindAsync(new Guid(x)));
                }

                foreach (var x in sjo.Context.Credentials)
                {
                    bundle.Credentials.Add(await database.Credentials.FindAsync(new Guid(x)));
                }

                foreach (var x in sjo.Context.ConnectionStrings)
                {
                    bundle.ConnectionStrings.Add(await database.ConnectionStrings.FindAsync(new Guid(x)));
                }

                bundle.Jobs[0].Dependencies.AddRange(bundle.Scripts);
                bundle.Jobs[0].Dependencies.AddRange(bundle.AssemblyInfo);
                bundle.Jobs[0].Dependencies.AddRange(bundle.Credentials);
                bundle.Jobs[0].Dependencies.AddRange(bundle.ConnectionStrings);
            }

            return bundle;
        }
    }

    public class SerializedJob
    {
        public string Name { get; set; }
        public Guid JobType { get; set; }
        public List<SerializedTrigger> Triggers { get; set; }
        public Dictionary<string, object> DataMap { get; set; }
        public List<IGuidId> Dependencies { get; set; }

        public SerializedJob()
        {
            Triggers = new List<SerializedTrigger>();
            Dependencies = new List<IGuidId>();
        }
    }

    public class SerializedTrigger
    {
        public string Cron { get; set; }
        public string Missfire { get; set; }
        public DateTimeOffset StartTime { get; set; }
        public string Name { get; set; }
    }
}
