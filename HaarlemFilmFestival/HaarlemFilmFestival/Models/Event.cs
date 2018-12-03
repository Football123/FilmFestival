using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaarlemFilmFestival.Models
{
    public class Event
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EindTime { get; set; }
        public double Price { get; set; }
        public double? Discount { get; set;}
        public int? Capacity { get; set;}
        public string Description { get; set; }

        // Koppeling naar Locatie
        public int Location_Id { get; set; }
        public virtual Location Location { get; set; }

        // Koppeling naar Orderregel
        public virtual ICollection<OrderRecord> OrderRecords { get; set; }
    }
}