using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HaarlemFilmFestival.Models
{
    public class FoodRegisterOrder
    {
        [Required] public Event Event { get; set; }
        [Required] public DateTime StartTime { get; set; }
        [Required] public double Price { get; set; }
        [Required] public OrderRecord RecordAmount { get; set; }
        public double? Discount { get; set; }
        [Required] public string Description { get; set; }

    }
}