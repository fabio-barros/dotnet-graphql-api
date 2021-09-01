using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HotChocolate;

namespace CommanderGQL.Models
{
    [GraphQLDescription("Represents the languages spoken in the film.")]
    public class Language
    {
        public Language()
        {
            this.Films = new HashSet<Film>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [StringLength(10)]
        public string LanguageName { get; set; }

        // [Required]
        // [ForeignKey("Film")]
        // public Guid FilmConnection { get; set; }
        // public virtual Film Film { get; set; }

        public virtual ICollection<Film> Films { get; set; }
    }
}