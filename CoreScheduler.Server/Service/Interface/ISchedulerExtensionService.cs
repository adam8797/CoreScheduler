using System.ServiceModel;

namespace CoreScheduler.Server.Service.Interface
{
    [ServiceContract]
    interface ISchedulerExtensionService
    {
        [OperationContract]
        void RegisterForStream(string id, string address, int port);


    }
}
