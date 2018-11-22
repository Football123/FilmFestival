using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaarlemFilmFestival.Models
{
    public class Klant
    {
        public int KlantId { get; set; }
        public string Naam { get; set; }
        public string Achternaam { get; set; }
        public DateTime Geboortedatum { get; set; }
        public string Emailadres { get; set; }
    }
}