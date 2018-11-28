using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaarlemFilmFestival.Models
{
    public class Orderregel
    {
        public int OrderregelId { get; set; }
        public int Regelaantal { get; set; }
        public string Tickettype { get; set; }
        public string Opmerkingen { get; set; }
        public int EventId { get; set; }
    }
}