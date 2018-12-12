using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HaarlemFilmFestival.Models
{
    [Table("Restaurants")]
    public class Restaurant
    {      
        public int Id { get; set; }
        public string RestaurantName { get; set; }
        public int Stars { get; set; }
        public string WebsiteLink { get; set; }

        // Koppeling Keuken
        public ICollection<Cuisine> Cuisines { get; set; }
    }
}