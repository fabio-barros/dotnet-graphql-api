using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommanderGQL.Models
{
    public class FilmCountry
    {
        [Required]
        public int CountryID { get; set; }

        [ForeignKey(nameof(CountryID))]
        public Country Country { get; set; }

        [Required]
        public int FilmId { get; set; }

        [ForeignKey(nameof(FilmId))]
        public Film Film { get; set; }

    }
}