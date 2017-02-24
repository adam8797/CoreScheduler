using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using CoreScheduler.Api;
using CoreScheduler.Server.Attributes;
using CoreScheduler.Server.Options;
using CoreScheduler.Server.Utilities;

namespace CoreScheduler.Server.Jobs.Python
{
    [AutoDiscover]
    [JobName("Python")]
    [JobCategory("Scripting Jobs")]
    [JobDescription("IronPython 2.7.5")]
    [FileExtension(".py")]
    [CommentString("#")]
    [ScintillaStyler("ScintillaWrapper.Stylers.PythonStyler", "vs_scintilla_wrapper")]
    [Guid("80f691a8-5fd5-41e1-a55f-72d9795c3e2d")]
    [JobOptionsType(typeof(ScriptJobOptions))]
    public class PythonJob : ScriptJob
    {
        protected override async Task Run()
        {
            // Log Start of Job
            BroadcastLog(EventLevel.Info, "Python Job began executing");

            // Add any engine options here. We run in 
            var engineOptions = new Dictionary<string, object>();

            if (Debug || !string.IsNullOrEmpty(Config.ConsoleStreaming))
            {
                engineOptions.Add("Debug", true);
            }

            // Setup the Python engine
            var engine = IronPython.Hosting.Python.CreateEngine(AppDomain.CurrentDomain, engineOptions);
            
            // I don't remember why I did this. It might be important down the line
            AppDomain.CurrentDomain.GetAssemblies().ForEach(x => engine.Runtime.LoadAssembly(x));
            
            // Reference all DLL files that were in the JobOptions
            Config.DllReferences
                .Where(x => !string.IsNullOrEmpty(x.Trim()))
                .ForEach(x => engine.Runtime.LoadAssembly(Assembly.Load(x)));

            // This assembly needs to be loaded for the standard python libraries to work
            engine.Runtime.LoadAssembly(Assembly.Load("IronPython.Modules"));

            // If we're streaming, we need to redirect the output
            if (!string.IsNullOrEmpty(Config.ConsoleStreaming))
            {
                engine.Runtime.IO.SetOutput(GetRedirectedStream(), Encoding.UTF8);
                engine.Runtime.IO.SetErrorOutput(GetRedirectedStream(), Encoding.UTF8);
            }

            // Add the execution directory
            var paths = engine.GetSearchPaths();
            paths.Add(GetExecutionDirectory());
            engine.SetSearchPaths(paths);

            var script = Scripts[0].Object;
            var scriptLocation = Scripts[0].Path;

            // Setup the script scope and load the script
            var scope = engine.CreateScope();

            // Log retrieval of script
            BroadcastLog(EventLevel.Info, "Script was loaded from Database ({0} chars)", script.ScriptSource.Length);
            var e = BroadcastLog(EventLevel.Info, "Script is executing");

            // Set the context variable
            if (Config.Context.Enable)
            {
                scope.SetVariable("ctx", GetContext(e));
            }

            var source = engine.CreateScriptSourceFromFile(scriptLocation);

            // Run the script
            source.Execute(scope);
        }
    }
}
