using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using csscript;
using CoreScheduler.Api;
using CoreScheduler.Server.Attributes;
using CoreScheduler.Server.Options;
using CSScriptLibrary;

namespace CoreScheduler.Server.Jobs.CSharp
{
    [AutoDiscover]
    [JobName("Embedded C#")]
    [JobCategory("Scripting Jobs")]
    [JobDescription("ScriptCS Hosted C# Job")]
    [FileExtension(".cs")]
    [CommentString("//")]
    [ScintillaStyler("ScintillaWrapper.Stylers.CSharpStyler", "vs_scintilla_wrapper")]
    [JobOptionsType(typeof(ScriptJobOptions))]
    [Guid("064b834b-a2f6-4b4d-8af4-6a3a69b07620")]
    public class CSharpJob : ScriptJob 
    {
        // Lock object used to make sure we only compile one project at a time
        internal static volatile object CompilationLock = new object();

        protected override async Task Run()
        {
            // Log Start of Job
            BroadcastLog(EventLevel.Info, "C# Job began executing");

            // Clear old search dirs, and add current job.
            // Sadly, these options are only global.
            // So, we will lock around the compilation.
            string assemblyPath = null;
            // 60 Seconds to try and obtain a lock
            for (int i = 60 - 1; i >= 0; i--)
            {
                if (Monitor.TryEnter(CompilationLock))
                {
                    try
                    {
                        var timer = Stopwatch.StartNew();
                        // This is the reason we lock. We can only change these settings globally
                        CSScript.GlobalSettings.SearchDirs = "";
                        CSScript.GlobalSettings.AddSearchDir(GetExecutionDirectory());

                        BroadcastLog(EventLevel.Debug, "Compilation beginning");

                        // Build the assembly.
                        var scripts = Scripts.Select(x => x.Path).ToArray();
                        var assemblies = Assemblies.ToArray();

                        assemblyPath = CSScript.CompileFiles(scripts, null, true, assemblies);

                        timer.Stop();
                        BroadcastLog(EventLevel.Debug, "Compilation finished ({0} ms)", timer.ElapsedMilliseconds);
                    }
                    finally
                    {
                        // Exit the lock
                        Monitor.Exit(CompilationLock);
                    }

                    break;
                }
                // We had to wait. Log it.
                BroadcastLog(EventLevel.Debug, "Waiting for compilation lock to clear. {0} seconds left...", i);
                Thread.Sleep(1000);
            }

            // 60 seconds have passed, without a lock. Compiler was unable to run.
            if (assemblyPath == null)
                throw new CompilerException("Unable to obtain an exclusive lock on the compiler within 60 seconds");


            // Reflect the API (its a dependency)
            var runnable = Assembly.ReflectionOnlyLoad("vs_core_api").GetType("CoreScheduler.Api.IRunnable");

            // Reflect the built assembly
            var assembly = Assembly.ReflectionOnlyLoadFrom(assemblyPath);

            // Find entry points
            var runnables = assembly.GetTypes().Where(x => runnable.IsAssignableFrom(x)).ToList();
            if (runnables.Count() > 1)
            {
                // Warn that there are too many entry points.
                BroadcastLog(EventLevel.Warning, "Multiple IRunnable entry points were found. Choosing the first.");
            }
            // Use the first one we find
            var target = runnables.First();

            // Log the one we found
            var e = BroadcastLog(EventLevel.Info, "Executing Entry Point in " + target.FullName);

            // AsmHelper is magic in that it can run our assembly in its own AppDomain. Which is hard.
            // Like really hard...
            using (var helper = new AsmHelper(assemblyPath, RunId.ToString(), true))
            {
                // Create a new IRunnable from the assembly
                var inst = helper.CreateAndAlignToInterface<IRunnable>(target.FullName);

                // Run it!
                inst.Main(GetContext(e));
            }
        }
    }
}
