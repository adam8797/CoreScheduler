using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CoreScheduler.Server.Utilities;

namespace CoreScheduler.Server.Database
{
    [Table("AssemblyData")]
    public class ReferenceAssembly : IGuidId
    {
        [Key]
        public Guid Id { get; set; }
        public byte[] Data { get; set; }
        public string FileName { get; set; }
    }
}
