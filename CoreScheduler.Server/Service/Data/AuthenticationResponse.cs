using System.Runtime.Serialization;

namespace CoreScheduler.Server.Service.Data
{
    [DataContract]
    class AuthenticationResponse
    {
        [DataMember]
        public bool Successful { get; set; }

        [DataMember]
        public string Identity { get; set; }
    }
}
