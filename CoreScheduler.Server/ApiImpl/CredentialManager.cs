using System.Collections.Generic;
using CoreScheduler.Api;

namespace CoreScheduler.Server.ApiImpl
{
    public class CredentialManager : Manager<ICredential>, ICredentialManager
    {
        public CredentialManager(IDictionary<string, ICredential> creds) : base(creds)
        {
        }
    }
}
