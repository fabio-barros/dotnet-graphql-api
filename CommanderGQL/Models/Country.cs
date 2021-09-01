using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HotChocolate;

namespace CommanderGQL.Models
{

    public class Country
    {
        public Country()
        {
            this.Films = new HashSet<Film>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }


        [Required]
        [StringLength(10)]
        public string CountryName { get; set; }

        public virtual ICollection<Film> Films { get; set; }

    }
}