using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HaarlemFilmFestival.Models
{
    [Table("Food")]
    public class Food : Event
    {
        public string RestaurantId { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}