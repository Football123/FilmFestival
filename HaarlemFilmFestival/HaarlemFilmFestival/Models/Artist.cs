using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HaarlemFilmFestival.Models
{
    [Table("Artists")]
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ArtistDescription { get; set; }

        // Koppeling naar Session
        public virtual ICollection<Theme> Themes { get; set; }
    }
}