using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommanderGQL.Models
{
    public class Plataform
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string LicenseKey { get; set; }
    }
}