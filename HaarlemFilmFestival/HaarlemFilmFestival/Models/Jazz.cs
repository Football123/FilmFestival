using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaarlemFilmFestival.Models
{
    public class Jazz
    {
        public int JazzId { get; set; }
        public string Rang { get; set; }
        public int Rangprijs { get; set; }
        public string Band { get; set; }
        public int EventId { get; set; }
    }
}