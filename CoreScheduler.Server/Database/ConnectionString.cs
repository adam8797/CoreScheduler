using System;
using CoreScheduler.Api;
using CoreScheduler.Server.Utilities;

namespace CoreScheduler.Server.Database
{
    public class ConnectionString : MarshalByRefObject, IConnectionString, IGuidId, INamed
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public ConnectionStringType ServerType { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
