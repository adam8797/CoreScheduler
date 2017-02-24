using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using CoreScheduler.Server.Utilities;

namespace CoreScheduler.Server.Database
{
    [Table("AssemblyInfo")]
    public class ReferenceAssemblyInfo : IGuidId, INamed, IFile
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string TreeDirectory { get; set; }
        public string FullName { get; set; }
        public string Version { get; set; }

        [NotMapped]
        [IgnoreDataMember]
        public ReferenceAssembly Linked { get; set; }
    }
}