using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HaarlemFilmFestival.Models
{
    public class OrderRecord
    {
        [Key, Column(Order = 0)]
        public int Order_Id { get; set; }
        [Key, Column(Order = 1)]
        public int Event_Id { get; set; }

        public int RecordAmount { get; set; }
        public string TicketType { get; set; }
        public string RecordDescription { get; set; }
        
        // Koppeling naar Order
        public virtual Order Order { get; set; }
        public virtual Event Event { get; set; }
        



    }
}