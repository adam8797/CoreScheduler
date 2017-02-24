using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using CoreScheduler.Server;

namespace CoreScheduler.Client.Desktop.Template
{
    public static class ScriptTemplates
    {
        public static async Task<string> GetTemplate(Type type)
        {
            var info = new JobTypeInfo(type);
            var ext = info.SourceFileExtension.Trim('.', ' ').ToLower();
            return await ReadAll(ext + "." + ext);
        }

        public static async Task<string> ReadAll(string templateName)
        {
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Template", templateName);
            if (File.Exists(path))
            {
                using (var reader = new StreamReader(path))
                {
                    return await reader.ReadToEndAsync();
                }
            }
            return "";
        }
    }
}
