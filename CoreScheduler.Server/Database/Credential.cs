using System;
using System.ComponentModel.DataAnnotations.Schema;
using CoreScheduler.Api;
using CoreScheduler.Server.Utilities;

namespace CoreScheduler.Server.Database
{
    public class Credential : MarshalByRefObject, IDomainCredential, IGuidId, INamed
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Domain { get; set; }

        public override string ToString()
        {
            return Name;
        }

    }
}
