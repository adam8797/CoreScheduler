using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using CoreScheduler.Server.Attributes;
using CoreScheduler.Server.Database;

namespace CoreScheduler.Server.Utilities
{
    public static class ScriptPreProcessor
    {
        private const string ReferenceString = "{0}core_ref";

        /// <summary>
        /// Extracts preprocess statements from the header of a script
        /// </summary>
        /// <param name="script">Script to parse</param>
        /// <returns></returns>
        public static async Task<List<Script>> Process(string script, Type jobType)
        {
            var imports = new List<string>();
            var lines = script.Split(new []{Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in lines)
            {
                if (line.StartsWith(GetComment(jobType)))
                    imports.Add(line.Substring(GetComment(jobType).Length).Trim().TrimEnd(';'));
            }

            var scripts = new List<Script>();
            var db = new DatabaseContext();
            foreach (var import in imports)
            {
                scripts.Add(await GetScriptFromNameOrId(import, db, jobType));
            }

            return scripts;
        }

        public static async Task<Script> GetScriptFromNameOrId(string import, DatabaseContext db, Type jobType)
        {
            Guid id;

            if (Guid.TryParse(import, out id))
                return await db.Scripts.FindAsync(id);
            
            if (await db.Scripts.AnyAsync(x => x.Name == import))
                return await db.Scripts.SingleAsync(x => x.Name == import);

            throw new FileNotFoundException(string.Format("Could not understand reference \"{0} {1}\"", GetComment(jobType), import));
        }

        public static async Task<List<Script>> ProcessFile(string path, Type jobType)
        {
            var builder = new StringBuilder();
            using (var reader = new StreamReader(path))
            {
                while (reader.Peek() > 0)
                {
                    var line = await reader.ReadLineAsync();
                    if (line == null || !line.StartsWith(ReferenceString))
                        break;

                    builder.AppendLine(line);
                }
            }

            return await Process(builder.ToString(), jobType);
        }

        private static string GetComment(Type t)
        {
            if (t.HasAttribute<CommentStringAttribute>())
                return string.Format(ReferenceString, t.GetAttribute<CommentStringAttribute>().Value);
            return "//";
        }
    }
}
