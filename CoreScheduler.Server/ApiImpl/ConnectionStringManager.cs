using System.Collections.Generic;
using System.Linq;
using CoreScheduler.Api;

namespace CoreScheduler.Server.ApiImpl
{
    public class ConnectionStringManager : Manager<IConnectionString>, IConnectionStringManager
    {
        public ConnectionStringManager(IDictionary<string, IConnectionString> values) : base(values)
        {
        }

        public IConnectionString[] ForType(ConnectionStringType type)
        {
            return Dictionary.Values.Where(x => x.ServerType == type).ToArray();
        }
    }
}
