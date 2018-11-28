using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaarlemFilmFestival.Models
{
    public class Event
    {
        public int EventId { get; set; }
        public DateTime Begintijd { get; set; }
        public DateTime Eindtijd { get; set; }
        public int Prijs { get; set; }
        public int Korting { get; set;}
        public int Capaciteit { get; set;}
        public string Omschrijving { get; set; }

        // Link naar Locatie
        public int LocatieId { get; set; }
    }
}