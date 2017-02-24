using System.ServiceModel;

namespace CoreScheduler.Server.Service.Interface
{
    [ServiceContract]
    interface IAuthenticationService
    {
        [OperationContract]
        bool Authenticate(string username, string password, string terminal);
    }
}
