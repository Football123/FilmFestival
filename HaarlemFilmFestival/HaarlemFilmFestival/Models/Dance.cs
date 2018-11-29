using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HaarlemFilmFestival.Models
{
    public class Dance : Event
    {
        public int ThemeId { get; set; }
        public int ArtistId { get; set; }

        //navigation properties
        public virtual Theme Theme { get; set; }
        public virtual Artist Artist { get; set; }

        // Koppeling naar Session
        public virtual ICollection<Theme> Themes { get; set; }
        
    }
}