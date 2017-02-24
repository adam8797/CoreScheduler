using System.Collections.Concurrent;
using CoreScheduler.Api.Contract;
using CoreScheduler.Server.Service.Interface;

namespace CoreScheduler.Server.Service.Impl
{
    class SchedulerExtensionService : ISchedulerExtensionService
    {
        public static ConcurrentBag<ConsoleRedirectionRequest> RegisteredClients =
            new ConcurrentBag<ConsoleRedirectionRequest>();


        public void RegisterForStream(string id, string address, int port)
        {
            var crr = new ConsoleRedirectionRequest
            {
                Id = id,
                Address = address,
                Port = port
            };
            
            RegisteredClients.Add(crr);
        }
    }
}
