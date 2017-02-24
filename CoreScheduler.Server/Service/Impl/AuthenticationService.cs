using System.DirectoryServices.AccountManagement;
using Common.Logging;
using CoreScheduler.Server.Service.Interface;

namespace CoreScheduler.Server.Service.Impl
{
    class AuthenticationService : IAuthenticationService
    {
        public bool Authenticate(string username, string password, string terminal)
        {
            var log = LogManager.GetLogger<AuthenticationService>();
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                log.Warn("Invalid authentication request. Username or password was empty");
                return false;
            }

            log.InfoFormat("Authenticating {0} from terminal {1}", username, terminal);

            var pc = new PrincipalContext(ContextType.Domain);

            return pc.ValidateCredentials(username, password);
        }
    }
}
