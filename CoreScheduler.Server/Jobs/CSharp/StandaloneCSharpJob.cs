using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using CoreScheduler.Api;
using CoreScheduler.Server.Attributes;
using CoreScheduler.Server.Options;

namespace CoreScheduler.Server.Jobs.CSharp
{
    [AutoDiscover]
    [JobName("Standalone C# Job")]
    [JobCategory("Scripting Jobs")]
    [JobDescription("ScriptCS External C# Job")]
    [FileExtension(".cs")]
    [CommentString("//")]
    [ScintillaStyler("ScintillaWrapper.Stylers.CSharpStyler", "vs_scintilla_wrapper")]
    [JobOptionsType(typeof(ScriptJobOptions))]
    [Guid("1bdca0a3-aedb-406f-9d44-b529d6efda5d")]
    public class StandaloneCSharpJob : ScriptJob
    {
        protected override async Task Run()
        {
            BroadcastLog(EventLevel.Info, "Beginning new Standalone C# Job");

            var watch = Stopwatch.StartNew();
            var scriptLocation = Scripts[0].Path;
            var procargs = "/nl" + " " + @"""" + scriptLocation + @"""";
            var startInfo = new ProcessStartInfo("cscs", procargs)
            {
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            var proc = new Process()
            {
                StartInfo = startInfo
            };

            var parent = BroadcastLog(EventLevel.Info, "Script Output");

            proc.OutputDataReceived += (sender, args) => BroadcastLog(EventLevel.Info, parent, args.Data);
            proc.ErrorDataReceived += (sender, args) => BroadcastLog(EventLevel.Info, parent, args.Data);

            try
            {
                proc.Start();

                proc.BeginErrorReadLine();
                proc.BeginOutputReadLine();

                BroadcastLog(EventLevel.Debug, "Waiting for exit...");
                proc.WaitForExit();

                watch.Stop();

                BroadcastLog(EventLevel.Info, "Compilation and run finished in {0}ms", watch.ElapsedMilliseconds);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                proc.Close();
            }

            
        }
    }
}
