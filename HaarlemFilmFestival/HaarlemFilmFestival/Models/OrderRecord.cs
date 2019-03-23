using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HaarlemFilmFestival.Models
{
    [Table("OrderRecords")]
    public class OrderRecord
    {
        [Key, Column(Order = 0)]
        public int Order_Id { get; set; }
        [Key, Column(Order = 1)]
        public int Event_Id { get; set; }

        public int RecordAmount { get; set; }
        [NotMapped]
        public int RecordAmountForKids { get; set; }
        public TicketType TicketType { get; set; }
        public string RecordDescription { get; set; }
        
        // Koppeling naar Order
        public virtual Order Order { get; set; }
        public virtual Event Event { get; set; }
    }
}