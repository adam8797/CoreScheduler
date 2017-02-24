using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using CoreScheduler.Client.Desktop.Utilities;
using CoreScheduler.Server.Database;

namespace CoreScheduler.Client.Desktop.Serializer.Versions
{
    class JobWriter10 : IJobWriter
    {
        public string Version { get { return "1.0"; } }

        private const int DataWidth = 50;
        private const int DataPad = 12;

        public XDocument Write(JobDependencyBundle bundle, JobRenderOptions options)
        {
            return new XDocument(
                WithAttr("version", Version, new XElement("core",
                    new XElement("jobs",
                        bundle.Jobs.Select(x => WithAttr("jobType", x.JobType.ToString(), WithName(x.Name, new XElement("job",
                            new XElement("triggers",
                                x.Triggers.Select(y => WithName(y.Name, new XElement("trigger",
                                    new XElement("cron", y.Cron),
                                    new XElement("missfire", y.Missfire),
                                    new XElement("starttime", y.StartTime.ToLocalTime().ToString("o")))))),
                            new XElement("jobData", x.DataMap.Select(y => AddElement(y.Key, y.Value))),
                            new XElement("dependencies", GetDependencies(x, options))))))),
                    new XElement("dependencies",
                    WithAttr("encrypted", options.EncryptConnectionStrings.ToString(),
                        new XElement("connectionStrings", bundle.ConnectionStrings.If(options.ExportConnectionStrings).Select(x =>
                            WithNameAndId(x.Name, x.Id.ToString(), new XElement("connectionString",
                                new XElement("value", x.Value.Encrypt(options.Secret, options.EncryptConnectionStrings)),
                                new XElement("serverType", x.ServerType.ToString().ToUpper())))))),
                    WithAttr("encrypted", options.EncryptCredentials.ToString(),
                        new XElement("credentials", bundle.Credentials.If(options.ExportCredentials).Select(x =>
                            WithNameAndId(x.Name, x.Id.ToString(), new XElement("credential",
                                new XElement("username", x.Username),
                                new XElement("password", x.Password.Encrypt(options.Secret, options.EncryptCredentials)),
                                new XElement("domain", x.Domain)))))),
                        new XElement("scripts", bundle.Scripts.Select(x =>
                            WithNameAndId(x.Name, x.Id.ToString(), new XElement("script",
                                new XElement("treeDirectory", x.TreeDirectory),
                                new XElement("jobType", x.JobTypeGuid.ToString()),
                                new XElement("data", FitData(x.Base64, DataWidth, DataPad)))))),
                        new XElement("assemblies", bundle.JoinAssemblies().Select(x =>
                            WithNameAndId(x.Name, x.Id.ToString(), new XElement("assembly",
                                new XElement("treeDirectory", x.TreeDirectory),
                                new XElement("fullname", x.FullName),
                                new XElement("filename", x.Linked.FileName),
                                new XElement("version", x.Version),
                                new XElement("data", FitData(Convert.ToBase64String(x.Linked.Data), DataWidth, DataPad))))))
                    ))));
        }

        private string FitData(string src, int width, int pad)
        {
            var lines = new List<string>();
            for (int i = 0; i < (src.Length / width) + (src.Length % width == 0 ? 0 : 1); i++)
            {
                var line = new string(' ', pad) + new string(src.Skip(width * i).Take(width).ToArray());
                lines.Add(line);
            }

            return "\n" + string.Join("\n", lines) + "\n" + new string(' ', pad - 4);
        }

        private XElement[] GetDependencies(SerializedJob job, JobRenderOptions options)
        {
            var elements = new List<XElement>();

            if (options.ExportConnectionStrings)
                elements.AddRange(job.Dependencies.OfType<ConnectionString>().Select(x => WithId(x.Id.ToString(), new XElement("connectionString"))));
            
            if (options.ExportCredentials)
                elements.AddRange(job.Dependencies.OfType<Credential>().Select(x => WithId(x.Id.ToString(), new XElement("credential"))));
            
            elements.AddRange(job.Dependencies.OfType<Script>().Select(x => WithId(x.Id.ToString(), new XElement("script"))));
            elements.AddRange(job.Dependencies.OfType<ReferenceAssemblyInfo>().Select(x => WithId(x.Id.ToString(), new XElement("assembly"))));

            return elements.ToArray();
        }

        private XElement WithName(string value, XElement src)
        {
            src.SetAttributeValue("name", value);
            return src;
        }

        private XElement WithId(string id, XElement src)
        {
            src.SetAttributeValue("id", id);
            return src;
        }

        private XElement WithNameAndId(string name, string id, XElement src)
        {
            src.SetAttributeValue("id", id);
            src.SetAttributeValue("name", name);
            return src;
        }

        private XElement AddElement(string key, object value)
        {
            var src = new XElement("add");
            src.SetAttributeValue("key", key);
            if (value != null)
            {
                src.SetAttributeValue("type", value.GetType().Name);
                src.SetAttributeValue("value", value.ToString());
            }
            return src;
        }

        private XElement WithAttr(string attr, string value, XElement src)
        {
            src.SetAttributeValue(attr, value);
            return src;
        }
    }
}
