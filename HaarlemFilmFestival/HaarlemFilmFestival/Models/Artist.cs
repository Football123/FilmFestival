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

        // Koppeling naar Session
        public virtual ICollection<Session> Session { get; set; }
    }
}