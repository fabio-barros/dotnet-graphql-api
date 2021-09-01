using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HotChocolate;

namespace CommanderGQL.Models
{
    [GraphQLDescription("Represents crew members, i.e. Executive Producer, Cinematographer, Sound Manager.")]
    public class CrewMember
    {
        public CrewMember()
        {
            this.Films = new HashSet<Film>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [Required]
        [StringLength(20)]
        public string Role { get; set; }

        public virtual ICollection<Film> Films { get; set; }

    }
}