using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HaarlemFilmFestival.Models
{
    [Table("Events")]
    public class Event
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public double Price { get; set; }
        public double? Discount { get; set;}
        public int? Capacity { get; set;}
        public string Description { get; set; }

        // Koppeling naar Locatie
       
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Location_Id { get; set; }
        [ForeignKey("Location_Id")]
        public virtual Location Location { get; set; }

        // Koppeling naar Orderregel
        public virtual ICollection<OrderRecord> OrderRecords { get; set; }
    }
}