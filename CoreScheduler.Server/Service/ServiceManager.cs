using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Description;
using Common.Logging;
using CoreScheduler.Server.Service.Impl;

namespace CoreScheduler.Server.Service
{
    public static class ServiceManager
    {
        private static readonly List<ServiceHost> _hosts;

        static ServiceManager()
        {
            _hosts = new List<ServiceHost>();
        }

        public static void Start()
        {
            string baseUri = "http://localhost:8980/";

            StartService(typeof(AuthenticationService), new Uri(baseUri + "Authentication"));
            StartService(typeof(SchedulerExtensionService), new Uri(baseUri + "Scheduler"));
        }

        public static void StopAll()
        {
            var log = LogManager.GetLogger(typeof(ServiceManager));
            log.Info("Closing all services.");
            foreach (var serviceHost in _hosts)
            {
                log.Debug("Closing " + serviceHost.SingletonInstance.GetType().Name);
                serviceHost.Close();
                ((IDisposable)serviceHost).Dispose();
                _hosts.Remove(serviceHost);
            }
        }

        private static void StartService(Type serviceType, Uri baseAddress)
        {
            var host = new ServiceHost(serviceType, baseAddress);

            var log = LogManager.GetLogger(serviceType);
            log.InfoFormat("Setting up service {0} on {1}", serviceType.Name, baseAddress.ToString());

            var smb = new ServiceMetadataBehavior
            {
                HttpGetEnabled = true,
                MetadataExporter = { PolicyVersion = PolicyVersion.Policy15 },
            };
            host.Description.Behaviors.Add(smb);

            log.Info("Opening service...");
            host.Open();

            _hosts.Add(host);
        }
    }
}
