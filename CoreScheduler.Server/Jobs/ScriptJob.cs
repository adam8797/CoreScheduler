using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using CoreScheduler.Api;
using CoreScheduler.Server.ApiImpl;
using CoreScheduler.Server.Database;
using CoreScheduler.Server.Options;
using CoreScheduler.Server.Utilities;

namespace CoreScheduler.Server.Jobs
{
    public abstract class ScriptJob : ScriptJob<ScriptJobOptions>
    {
    }

    public abstract class ScriptJob<TConfig> : Job<TConfig> where TConfig : ScriptJobOptions, new()
    {
        protected List<FilePath<Script>> Scripts { get; private set; }
        protected List<string> Assemblies { get; set; }

        protected IContext GetContext(JobEvent parent)
        {
            var expand = Context.JobDetail.JobDataMap.Unpack<TConfig>();

            if (expand.Context.Enable)
            {
                return new Context<TConfig>(expand.Context, Context, parent, RunId, this);
            }

            return null;
        }

        protected async Task<Script> GetScript(Guid id)
        {
            var script = await Database.Scripts.FindAsync(id);

            if (script == null)
                throw new Exception("Script not found in Database");

            return script;
        }

        protected async Task<Script> GetScript()
        {
            return await GetScript(new Guid(GetConfig<TConfig>().ScriptId));
        }

        protected async Task<string> SaveScript(Script s)
        {
            var path = Path.Combine(GetExecutionDirectory(), s.Name);
            using (var writer = new StreamWriter(path))
            {
                await writer.WriteAsync(s.ScriptSource);
            }
            return path;
        }

        protected async Task<List<FilePath<Script>>> LoadScripts(params string[] externalRefs)
        {
            var files = new List<FilePath<Script>>();
            var script = await GetScript();
            var options = Context.JobDetail.JobDataMap.Unpack<ScriptJobOptions>();

            var db = new DatabaseContext();
            files.Add(new FilePath<Script>(script, await SaveScript(script)));

            var refs = (await ScriptPreProcessor.Process(script.ScriptSource, GetType()));

            foreach (var reffile in externalRefs)
            {
                refs.Add(await ScriptPreProcessor.GetScriptFromNameOrId(reffile, db, GetType()));
            }

            foreach (var optionsScriptReference in options.ScriptReferences)
            {
                refs.Add(await ScriptPreProcessor.GetScriptFromNameOrId(optionsScriptReference, db, GetType()));
            }

            foreach (var s in refs)
            {
                files.Add(new FilePath<Script>(s, await SaveScript(s)));
            }

            AddEvent(EventLevel.Info, "Scripts were loaded from Database ({0} files)", files.Count);
            return files;
        }

        protected async Task<List<string>> LoadAssemblies()
        {
            var files = new List<string>();
            var db = new DatabaseContext();
            var options = Context.JobDetail.JobDataMap.Unpack<ScriptJobOptions>();

            foreach (var optionsDllReference in options.DllReferences)
            {
                var asm = await db.Assemblies.FindAsync(new Guid(optionsDllReference));
                var path = Path.Combine(GetExecutionDirectory(), "Assembly Cache", asm.Id.ToString(), asm.FileName);
                if (!File.Exists(path))
                {
                    File.WriteAllBytes(path, asm.Data);
                }
                files.Add(path);
            }

            return files;
        }

        protected override async Task Setup()
        {
            Scripts = await LoadScripts();
            Assemblies = await LoadAssemblies();
        }
    }

    public class FilePath<T>
    {
        public T Object { get; set; }
        public string Path { get; set; }

        public FilePath(T obj, string path)
        {
            Object = obj;
            Path = path;
        }
    }
}
