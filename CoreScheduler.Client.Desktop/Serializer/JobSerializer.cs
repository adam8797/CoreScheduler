using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using CoreScheduler.Client.Desktop.Serializer.Versions;

namespace CoreScheduler.Client.Desktop.Serializer
{
    public static class JobSerializer
    {
        private static List<IJobReader> _jobReaders = new List<IJobReader>();
        private static IJobWriter _jobWriter;

        static JobSerializer()
        {
            _jobReaders.Add(new JobReader10());
            _jobWriter = new JobWriter10();
        }

        private static IJobReader GetReader(XDocument doc)
        {
            if (doc == null || doc.Root == null)
                throw new XmlException();

            var versionAttr = doc.Root.Attribute("version");

            if (versionAttr == null)
                throw new XmlException("Root element must contain a version attribute.");

            var fileVersion = versionAttr.Value;

            var reader = _jobReaders.SingleOrDefault(x => x.Version == fileVersion);

            if (reader == null)
                throw new Exception("Unable to find JobReader for file version " + fileVersion);

            return reader;
        }

        public static JobDependencyBundle Read(string filePath, string secret)
        {
            using (var file = File.OpenRead(filePath))
            {
                var doc = XDocument.Load(file);

                var reader = GetReader(doc);

                return reader.Read(doc, secret);
            }
        }

        public static bool CheckPassword(string filePath, string password)
        {
            if (string.IsNullOrEmpty(password))
                return false;

            using (var file = File.OpenRead(filePath))
            {
                var doc = XDocument.Load(file);

                var reader = GetReader(doc);

                return reader.CheckPassword(doc, password);
            }
        }

        public static bool IsEncrypted(string filePath)
        {
            using (var file = File.OpenRead(filePath))
            {
                var doc = XDocument.Load(file);

                var reader = GetReader(doc);

                return reader.IsEncrypted(doc);
            }
        }

        public static XDocument Render(JobDependencyBundle bundle, JobRenderOptions options)
        {
            return _jobWriter.Write(bundle, options);
        }

        public static void Write(JobDependencyBundle bundle, string filePath, JobRenderOptions options)
        {
            var doc = Render(bundle, options);
            using (var writer = File.Open(filePath, FileMode.Create))
            {
                doc.Save(writer);
            }
        }
    }

    public class JobRenderOptions
    {
        public string Secret { get; set; }

        public bool ExportCredentials { get; set; }
        public bool EncryptCredentials { get; set; }

        public bool ExportConnectionStrings { get; set; }
        public bool EncryptConnectionStrings { get; set; }

        public JobRenderOptions()
        {
            
        }

        public JobRenderOptions(string secret)
        {
            EncryptConnectionStrings = true;
            EncryptCredentials = true;
            ExportCredentials = true;
            ExportConnectionStrings = true;
            Secret = secret;
        }
           

    }

    public interface IJobReader
    {
        string Version { get; }
        JobDependencyBundle Read(XDocument doc, string secret);
        bool IsEncrypted(XDocument doc);
        bool CheckPassword(XDocument doc, string password);
    }

    public interface IJobWriter
    {
        string Version { get; }
        XDocument Write(JobDependencyBundle bundle, JobRenderOptions options);
    }
}
