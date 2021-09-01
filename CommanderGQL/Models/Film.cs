using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HotChocolate;

namespace CommanderGQL.Models
{
    public class Film
    {
        public Film()
        {
            this.Languages = new HashSet<Language>();
            this.Actors = new HashSet<Actor>();
            this.CrewMembers = new HashSet<CrewMember>();
            this.Countries = new HashSet<Country>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        // [Required]
        // [StringLength(20)]
        // [GraphQLDescription("Represents the country in which.")]
        // public string Country { get; set; }

        [Required]
        [MaxLength(4)] public int Year { get; set; }

        [Required]
        [MaxLength(50)]
        public int Length { get; set; }

        [Required]
        [StringLength(20)]
        public string Color { get; set; }

        [Required]
        [StringLength(10)]
        public string Aspect { get; set; }

        [ForeignKey("Director")]
        public Guid DirectorConnection { get; set; }
        public virtual Director Director { get; set; }

        public virtual ICollection<Language> Languages { get; set; }

        [GraphQLDescription("Represents the countries involved in the productions of the film.")]
        public virtual ICollection<Country> Countries { get; set; }
        public virtual ICollection<Actor> Actors { get; set; }
        public virtual ICollection<CrewMember> CrewMembers { get; set; }
    }
}