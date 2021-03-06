using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommanderGQL.Models
{
    public class Plataform
    {
        public Plataform()
        {
            this.Commands = new HashSet<Command>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string LicenseKey { get; set; }

        public virtual ICollection<Command> Commands { get; set; }


    }
}
