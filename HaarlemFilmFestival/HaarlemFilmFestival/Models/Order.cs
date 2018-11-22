using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaarlemFilmFestival.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string Betaalmethode { get; set; }
        public DateTime Ordertijd { get; set; }
        public Boolean Betaald { get; set; }
        public int Code { get; set; }
        public int Aantal { get; set; }
        public int Totaalprijs { get; set; }
        public int KlantId { get; set; }
        public int OrderregelId { get; set; }
    }
}