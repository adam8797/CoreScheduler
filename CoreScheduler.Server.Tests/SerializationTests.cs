using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using CoreScheduler.Client.Desktop.Serializer;
using CoreScheduler.Server.Database;
using CoreScheduler.Server.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoreScheduler.Tests.Server
{
    [TestClass]
    public class SerializationTests
    {
        private const string Secret = "AlwaysLookOnTheBrightSideOfLife";

        [TestMethod]
        public void TestNoEncryptRead()
        {
            var read = JobSerializer.Read(@"C:\Users\aschiavone\Documents\Git\vs_core_scheduler\vs_core_scheduler_client\Serializer\template.xml", Secret);

            //Connection Strings

            TestBundleEquality(BuildNewBundle(), read);
        }

        [TestMethod]
        public void TestEncryptRead()
        {
            var read = JobSerializer.Read(@"C:\Users\aschiavone\Documents\Git\vs_core_scheduler\vs_core_scheduler_client\Serializer\template.enc.xml", Secret);
       
            TestBundleEquality(BuildNewBundle(), read);
        }

        [TestMethod]
        public void TestNoEncryptRoundtrip()
        {
            var bundle = BuildNewBundle();
            var file = Path.Combine(Path.GetTempPath(), Path.GetTempFileName());
            JobSerializer.Write(bundle, file, new JobRenderOptions()
            {
                ExportConnectionStrings = true,
                ExportCredentials = true,
                EncryptCredentials = false,
                EncryptConnectionStrings = false,
                Secret = Secret
            });

            var read = JobSerializer.Read(file, Secret);

            TestBundleEquality(bundle, read);
        }

        [TestMethod]
        public void TestEncryptRoundtrip()
        {
            var bundle = BuildNewBundle();
            var file = Path.Combine(Path.GetTempPath(), Path.GetTempFileName());
            JobSerializer.Write(bundle, file, new JobRenderOptions()
            {
                ExportConnectionStrings = true,
                ExportCredentials = true,
                EncryptCredentials = true,
                EncryptConnectionStrings = true,
                Secret = Secret
            });

            var read = JobSerializer.Read(file, Secret);

            TestBundleEquality(bundle, read);
        }

        [TestMethod]
        public void TestSemiEncryptRoundtrip()
        {
            var bundle = BuildNewBundle();
            var file = Path.Combine(Path.GetTempPath(), Path.GetTempFileName());
            JobSerializer.Write(bundle, file, new JobRenderOptions()
            {
                ExportConnectionStrings = true,
                ExportCredentials = true,
                EncryptCredentials = true,
                EncryptConnectionStrings = false,
                Secret = Secret
            });

            var read = JobSerializer.Read(file, Secret);

            TestBundleEquality(bundle, read);

            bundle = BuildNewBundle();
            file = Path.Combine(Path.GetTempPath(), Path.GetTempFileName());
            JobSerializer.Write(bundle, file, new JobRenderOptions()
            {
                ExportConnectionStrings = true,
                ExportCredentials = true,
                EncryptCredentials = false,
                EncryptConnectionStrings = true,
                Secret = Secret
            });

            read = JobSerializer.Read(file, Secret);

            TestBundleEquality(bundle, read);
        }

        [TestMethod]
        public void TestNoExportNoEncrypt()
        {
            var bundle = BuildNewBundle();
            var file = Path.Combine(Path.GetTempPath(), Path.GetTempFileName());
            JobSerializer.Write(bundle, file, new JobRenderOptions()
            {
                ExportConnectionStrings = false,
                ExportCredentials = false,
                EncryptCredentials = false,
                EncryptConnectionStrings = false,
                Secret = Secret
            });

            var read = JobSerializer.Read(file, Secret);

            bundle.ConnectionStrings.Clear();
            bundle.Credentials.Clear();

            bundle.Jobs.ForEach(x => x.Dependencies.RemoveAll(y => y is ConnectionString));
            bundle.Jobs.ForEach(x => x.Dependencies.RemoveAll(y => y is Credential));

            TestBundleEquality(bundle, read);
        }

        private void TestPropertiesSimple(object expected, object actual)
        {
            Assert.AreEqual(expected.GetType(), actual.GetType());
            
            var props = expected.GetType().GetProperties();

            foreach (var propertyInfo in props)
            {
                if (Attribute.IsDefined(propertyInfo, typeof(IgnoreDataMemberAttribute)))
                    continue;

                var expectedVal = propertyInfo.GetValue(expected);
                var actualVal = propertyInfo.GetValue(actual);

                if (typeof(ICollection).IsAssignableFrom(propertyInfo.PropertyType))
                    CollectionAssert.AreEquivalent((ICollection)expectedVal, (ICollection)actualVal, "On Property: " + expected.GetType().Name + "." + propertyInfo.Name);
                else
                    Assert.AreEqual(expectedVal, actualVal, "On Property: " + expected.GetType().Name + "." + propertyInfo.Name);
            }
        }

        private void TestBundleEquality(JobDependencyBundle template, JobDependencyBundle test)
        {
            //Connection Strings
            Assert.AreEqual(template.ConnectionStrings.Count, test.ConnectionStrings.Count);
            for (var i = 0; i < template.ConnectionStrings.Count; i++)
            {
                var expected = template.ConnectionStrings[i];
                var actual = test.ConnectionStrings[i];
                TestPropertiesSimple(expected, actual);
            }


            //Credentials
            Assert.AreEqual(template.Credentials.Count, test.Credentials.Count);
            for (int i = 0; i < template.Credentials.Count; i++)
            {
                var expected = template.Credentials[i];
                var actual = test.Credentials[i];

                TestPropertiesSimple(expected, actual);
            }

            // Scripts
            Assert.AreEqual(template.Scripts.Count, test.Scripts.Count);
            for (int i = 0; i < template.Scripts.Count; i++)
            {
                var expected = template.Scripts[i];
                var actual = test.Scripts[i];

                TestPropertiesSimple(expected, actual);
            }

            // Assembly Info
            Assert.AreEqual(template.AssemblyInfo.Count, test.AssemblyInfo.Count);
            for (int i = 0; i < template.AssemblyInfo.Count; i++)
            {
                var expected = template.AssemblyInfo[i];
                var actual = test.AssemblyInfo[i];

                TestPropertiesSimple(expected, actual);
            }

            // Assemblies
            Assert.AreEqual(template.AssemblyData.Count, test.AssemblyData.Count);
            for (int i = 0; i < template.AssemblyData.Count; i++)
            {
                var expected = template.AssemblyData[i];
                var actual = test.AssemblyData[i];

                TestPropertiesSimple(expected, actual);
            }

            // Jobs
            Assert.AreEqual(template.Jobs.Count, test.Jobs.Count);
            for (int i = 0; i < template.Jobs.Count; i++)
            {
                var expected = template.Jobs[i];
                var actual = test.Jobs[i];

                Assert.AreEqual(expected.Name, actual.Name);
                CollectionAssert.AreEquivalent(expected.DataMap, actual.DataMap);

                for (int j = 0; j < expected.Dependencies.Count; j++)
                {
                    var expectedDep = expected.Dependencies[j];
                    var actualDep = actual.Dependencies[j];

                    TestPropertiesSimple(expectedDep, actualDep);
                }

                for (int j = 0; j < expected.Triggers.Count; j++)
                {
                    var expectedTrigger = expected.Triggers[j];
                    var actualTrigger = actual.Triggers[j];

                    Assert.AreEqual(expectedTrigger.Cron, actualTrigger.Cron);
                    Assert.AreEqual(expectedTrigger.Missfire, actualTrigger.Missfire);
                    Assert.AreEqual(expectedTrigger.StartTime, actualTrigger.StartTime);
                }

                for (int j = 0; j < expected.Dependencies.Count; j++)
                {
                    TestPropertiesSimple(expected.Dependencies[j], actual.Dependencies[j]);
                }
            }

            // Validity
            for (int i = 0; i < template.Jobs.Count; i++)
            {
                for (int j = 0; j < template.Jobs[i].Dependencies.Count; j++)
                {
                    var dep = test.Jobs[i].Dependencies[j];

                    if (dep.GetType() == typeof(ConnectionString))
                        MatchReference(test.ConnectionStrings, dep);

                    else if (dep.GetType() == typeof(Credential))
                        MatchReference(test.Credentials, dep);

                    else if (dep.GetType() == typeof(Script))
                        MatchReference(test.Scripts, dep);

                    else if (dep.GetType() == typeof(ReferenceAssembly))
                        MatchReference(test.AssemblyData, dep);

                    else if (dep.GetType() == typeof(ReferenceAssemblyInfo))
                        MatchReference(test.AssemblyInfo, dep);
                }
            }
        }

        private void MatchReference<T>(IEnumerable<T> source, T item) where T: IGuidId
        {
            var jobdep = item;
            var depdep = source.SingleOrDefault(x => x.Id == jobdep.Id);

            Assert.AreSame(jobdep, depdep);
        }


        private string Encrypt(string plaintext, string secret, bool enc)
        {
            if (!enc)
                return plaintext;

            return StringEncryption.SimpleEncryptWithPassword(plaintext, secret);
        }

        private string Decrpyt(string ciphertext, string secret, bool enc)
        {
            if (!enc)
                return ciphertext;

            return StringEncryption.SimpleDecryptWithPassword(ciphertext, secret);
        }

        private JobDependencyBundle BuildNewBundle(bool enc = false)
        {
            var bundle = new JobDependencyBundle()
            {
                ConnectionStrings = new List<ConnectionString>()
                {
                    new ConnectionString()
                    {
                        Id = new Guid("bb56ac2e-85f9-4221-84cc-2ffa879d3e56"),
                        Value = Encrypt("Server=localhost; Initial Catalog=Quartz;", Secret, enc),
                        Name = "Localhost",
                        ServerType = Api.ConnectionStringType.MsSql
                    }
                },
                Credentials = new List<Credential>()
                {
                    new Credential()
                    {
                        Name = "Local Admin",
                        Id = new Guid("dd6d9e51-8047-4f8a-82f5-5d583e19952d"),
                        Username = Encrypt("Administrator", Secret, enc),
                        Password = Encrypt("123456", Secret, enc),
                        Domain = Encrypt("local", Secret, enc)
                    }
                },
                Scripts = new List<Script>()
                {
                    new Script()
                    {
                        Name = "specialstory.txt",
                        Id = new Guid("335f7163-4d57-42f7-94f5-28aef217555e"),
                        TreeDirectory = "books",
                        JobTypeGuid = new Guid("5e380ea3-805a-4551-ab89-dbb881bbde29"),
                        ScriptSource = "Far out in the uncharted backwaters of the unfashionable end of the western spiral arm of the Galaxy lies a small unregarded yellow sun. Orbiting this at a distance of roughly ninety-two million miles is an utterly insignificant little blue green planet whose ape-descended life forms are so amazingly primitive that they still think digital watches are a pretty neat idea. This planet has - or rather had - a problem, which was this: most of the people on it were unhappy for pretty much of the time. Many solutions were suggested for this problem, but most of these were largely concerned with the movements of small green pieces of paper, which is odd because on the whole it wasn't the small green pieces of paper that were unhappy. And so the problem remained; lots of the people were mean, and most of them were miserable, even the ones with digital watches. Many were increasingly of the opinion that they'd all made a big mistake in coming down from the trees in the first place. And some said that even the trees had been a bad move, and that no one should ever have left the oceans. And then, one Thursday, nearly two thousand years after one man had been nailed to a tree for saying how great it would be to be nice to people for a change, one girl sitting on her own in a small cafe in Rickmansworth suddenly realized what it was that had been going wrong all this time, and she finally knew how the world could be made a good and happy place. This time it was right, it would work, and no one would have to get nailed to anything. Sadly, however, before she could get to a phone to tell anyone about it, a terribly stupid catastrophe occurred, and the idea was lost forever. This is not her story."
                    }
                },
                AssemblyData = new List<ReferenceAssembly>()
                {
                    new ReferenceAssembly()
                    {
                        Id = new Guid("1f050374-8dcc-46aa-a14c-7631ca1e2c05"),
                        FileName = "BusinessObjects.DSWS.WebIShared.dll",
                        Data = File.ReadAllBytes(@"Pick a file") //ToDo: Pick a file
                    }
                },
                AssemblyInfo = new List<ReferenceAssemblyInfo>()
                {
                    new ReferenceAssemblyInfo()
                    {
                        TreeDirectory = "BusinessObjects",
                        FullName = "BusinessObjects.DSWS.WebIShared, Version=14.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304",
                        Version = "14.0.2000.0",
                        Id = new Guid("1f050374-8dcc-46aa-a14c-7631ca1e2c05"),
                        Name = "BusinessObjects.DSWS.WebIShared"
                    }
                },
                Jobs = new List<SerializedJob>()
                {
                    new SerializedJob()
                    {
                        DataMap = new Dictionary<string, object>()
                        {
                            {"foo", "bar"},
                            {"bar", "baz"}
                        },
                        Name = "Server Monitor",
                        Triggers = new List<SerializedTrigger>()
                        {
                            new SerializedTrigger()
                            {
                                Cron = "*/5 * * * * ?",
                                Missfire = "DoNothing",
                                StartTime = DateTime.Parse("2008-04-10T06:30:00.0000000")
                            }
                        },
                        Dependencies = new List<IGuidId>()
                    }
                }
            };


            bundle.Jobs[0].Dependencies.Add(bundle.ConnectionStrings[0]);
            bundle.Jobs[0].Dependencies.Add(bundle.Credentials[0]);
            bundle.Jobs[0].Dependencies.Add(bundle.Scripts[0]);
            bundle.Jobs[0].Dependencies.Add(bundle.AssemblyInfo[0]);

            return bundle;
        }
    }
}
