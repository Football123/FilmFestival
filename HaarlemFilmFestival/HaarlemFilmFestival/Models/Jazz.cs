using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaarlemFilmFestival.Models
{
    public class Jazz : Event
    {
        public int JazzId { get; set; }
        public string Band { get; set; }
        public new string Omschrijving { get; set; }
    }
}