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
        public int SessionId { get; set; }
        public int ArtistId { get; set; }

        //navigation properties
        public virtual Session Session { get; set; }
        public virtual Artist Artist { get; set; }

        // Koppeling naar Session
        public virtual ICollection<Session> Sessions { get; set; }
        
    }
}