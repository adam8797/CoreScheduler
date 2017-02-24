using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using CoreScheduler.Api;
using CoreScheduler.Server.Database;
using CoreScheduler.Server.Utilities;

namespace CoreScheduler.Client.Desktop.Serializer.Versions
{
    class JobReader10 : IJobReader
    {
        public string Version { get { return "1.0"; } }

        public JobDependencyBundle Read(XDocument doc, string secret)
        {
            var bundle = new JobDependencyBundle();

            var core = doc.Root;

            var dependencies = core.Element("dependencies");
            if (dependencies != null)
            {
                // Connection Strings
                var connectionStrings = dependencies.Element("connectionStrings");
                if (connectionStrings != null)
                {
                    var enc = connectionStrings.IsEncrypted();

                    bundle.ConnectionStrings = connectionStrings.Elements("connectionString").Select(x =>
                    {
                        var cn = new ConnectionString()
                        {
                            Name = x.Attribute("name").GetSafeValue(),
                            Id = x.Attribute("id").GetSafeValueGuid(),
                            Value = x.Element("value").GetSafeValueDecrypt(secret, enc)
                        };

                        switch (x.Element("serverType").GetSafeValue().ToUpper())
                        {
                            case "MSSQL":
                                cn.ServerType = ConnectionStringType.MsSql;
                                break;
                            case "MYSQL":
                                cn.ServerType = ConnectionStringType.MySql;
                                break;
                            case "TERADATA":
                                cn.ServerType = ConnectionStringType.Teradata;
                                break;
                        }

                        return cn;
                    }).ToList();
                }

                // Credentials
                var credentials = dependencies.Element("credentials");
                if (credentials != null)
                {
                    var val = credentials.Attribute("encrypted").GetSafeValue().ToUpper();
                    var enc = val == "TRUE";

                    bundle.Credentials = credentials.Elements("credential").Select(x => new Credential()
                    {
                        Name = x.Attribute("name").GetSafeValue(),
                        Id = x.Attribute("id").GetSafeValueGuid(),
                        Username = x.Element("username").GetSafeValue(),
                        Password = x.Element("password").GetSafeValueDecrypt(secret, enc),
                        Domain = x.Element("domain").GetSafeValue()
                    }).ToList();
                }

                // Scripts
                var scripts = dependencies.Element("scripts");
                if (scripts != null)
                {
                    bundle.Scripts = scripts.Elements("script").Select(x => new Script()
                    {
                        Name = x.Attribute("name").GetSafeValue(),
                        Id = x.Attribute("id").GetSafeValueGuid(),
                        TreeDirectory = x.Element("treeDirectory").GetSafeValue(),
                        JobTypeGuid = x.Element("jobType").GetSafeValueGuid(),
                        Base64 = x.Element("data").ReadDataBlockBase64String()
                    }).ToList();
                }


                // Assemblies
                var assemblies = dependencies.Element("assemblies");
                if (assemblies != null)
                {
                    var tuples = assemblies.Elements("assembly").Select(x => new
                    {
                        AssemblyData = new ReferenceAssembly()
                        {
                            Data = x.Element("data").ReadDataBlock(),
                            FileName = x.Element("filename").GetSafeValue(),
                            Id = x.Attribute("id").GetSafeValueGuid()
                        },
                        AssemblyInfo = new ReferenceAssemblyInfo()
                        {
                            Id = x.Attribute("id").GetSafeValueGuid(),
                            Name = x.Attribute("name").GetSafeValue(),
                            FullName = x.Element("fullname").GetSafeValue(),
                            Version = x.Element("version").GetSafeValue(),
                            TreeDirectory = x.Element("treeDirectory").GetSafeValue()
                        }
                    });

                    bundle.AssemblyInfo = tuples.Select(x => x.AssemblyInfo).ToList();
                    bundle.AssemblyData = tuples.Select(x => x.AssemblyData).ToList();
                }
            }

            var jobs = core.Element("jobs");
            if (jobs != null)
            {
                bundle.Jobs = jobs.Elements("job").Select(x =>
                {
                    var job = new SerializedJob
                    {
                        Name = x.Attribute("name").GetSafeValue(),
                        JobType = x.Attribute("jobType").GetSafeValueGuid()
                    };

                    var triggers = x.Element("triggers");
                    if (triggers != null)
                    {
                        job.Triggers = triggers.Elements("trigger").Select(y => new SerializedTrigger()
                        {
                            Cron = y.Element("cron").GetSafeValue(),
                            Missfire = y.Element("missfire").GetSafeValue(),
                            StartTime = y.Element("starttime").GetSafeValueDateTime()
                        }).ToList();
                    }

                    var jobData = x.Element("jobData");
                    if (jobData != null)
                    {
                        job.DataMap = jobData.Elements("add")
                            .ToDictionary<XElement, string, object>(y => y.Attribute("key").GetSafeValue(),
                                y =>
                                {
                                    var value = y.Attribute("value").GetSafeValue();
                                    var type = y.Attribute("type").GetSafeValue();

                                    if (type == typeof(int).Name) return Convert.ToInt32(value);
                                    if (type == typeof(long).Name) return Convert.ToInt64(value);
                                    if (type == typeof(float).Name) return Convert.ToSingle(value);
                                    if (type == typeof(double).Name) return Convert.ToDouble(value);
                                    if (type == typeof(bool).Name) return Convert.ToBoolean(value);
                                    if (type == typeof(short).Name) return Convert.ToInt16(value);
                                    if (type == typeof(char).Name) return Convert.ToChar(value);
                                    if (type == typeof(byte).Name) return Convert.ToByte(value);

                                    return value;
                                });
                    }

                    var jobdependencies = x.Element("dependencies");
                    if (jobdependencies != null)
                    {
                        job.Dependencies = new List<IGuidId>();

                        job.Dependencies.AddRange(
                            jobdependencies.Elements("connectionString")
                                .Select(
                                    y =>
                                        bundle.ConnectionStrings.SingleOrDefault(
                                            z => z.Id == y.Attribute("id").GetSafeValueGuid())));

                        job.Dependencies.AddRange(
                            jobdependencies.Elements("credential")
                                .Select(
                                    y =>
                                        bundle.Credentials.SingleOrDefault(
                                            z => z.Id == y.Attribute("id").GetSafeValueGuid())));

                        job.Dependencies.AddRange(
                            jobdependencies.Elements("script")
                                .Select(
                                    y =>
                                        bundle.Scripts.SingleOrDefault(
                                            z => z.Id == y.Attribute("id").GetSafeValueGuid())));

                        job.Dependencies.AddRange(
                            jobdependencies.Elements("assembly")
                                .Select(
                                    y =>
                                        bundle.AssemblyInfo.SingleOrDefault(
                                            z => z.Id == y.Attribute("id").GetSafeValueGuid())));


                    }


                    return job;
                }).ToList();
            }

            return bundle;
        }

        public bool IsEncrypted(XDocument doc)
        {
            return doc.Descendants().Any(x => x.Attribute("encrypted").GetSafeValue().ToUpper() == "TRUE");
        }

        public bool CheckPassword(XDocument doc, string password)
        {
            if (!IsEncrypted(doc))
                return true;

            var credential = doc.Descendants("credentials")
                .First(x => x.Attribute("encrypted").GetSafeValue().ToUpper() == "TRUE")
                .Element("credential");

            if (credential != null)
            {
                var res = StringEncryption.SimpleDecryptWithPassword(credential.Element("password").GetSafeValue(), password);
                return res != null;
            }

            var connectionString = doc.Descendants("connectionStrings")
                .First(x => x.Attribute("encrypted").GetSafeValue().ToUpper() == "TRUE")
                .Element("connectionString");

            if (connectionString != null)
            {
                var res = StringEncryption.SimpleDecryptWithPassword(connectionString.Element("value").GetSafeValue(), password);
                return res != null;
            }


            // We should never ever ever be here
            // Like... ever...
            throw new Exception("Pigs are flying");
        }
    }
}
