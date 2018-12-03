using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaarlemFilmFestival.Models
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ArtistDescription { get; set; }

        // Koppeling naar Session
        public virtual ICollection<Theme> Themes { get; set; }
    }
}