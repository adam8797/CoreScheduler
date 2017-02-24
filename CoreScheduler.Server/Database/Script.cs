using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using CoreScheduler.Server.Utilities;

namespace CoreScheduler.Server.Database
{
    public class Script : IGuidId, INamed, IFile
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Base64 { get; set; }

        [Required]
        public Guid JobTypeGuid { get; set; }

        public string TreeDirectory { get; set; }

        [NotMapped]
        public string ScriptSource
        {
            get
            {

                if (string.IsNullOrEmpty(Base64))
                    return "";
                return Encoding.UTF8.GetString(Convert.FromBase64String(Base64));
            }
            set { Base64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(value)); }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
