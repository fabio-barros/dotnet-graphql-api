using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommanderGQL.Models
{
    public class Director
    {
        public Director()
        {
            this.Films = new HashSet<Film>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        // public Guid Film FilmId { get; set; }

        public virtual ICollection<Film> Films { get; set; }
    }
}