using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaarlemFilmFestival.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime OrderTime { get; set; }
        public Boolean Paid { get; set; }
        public int Code { get; set; }

        // Koppeling naar Klant
        public virtual Customer Customer { get; set; }
        public int Customer_Id { get; set; }

        // Koppeling naar Orderregels
        public ICollection<OrderRecord> OrderRecords { get; set; }
    }
}