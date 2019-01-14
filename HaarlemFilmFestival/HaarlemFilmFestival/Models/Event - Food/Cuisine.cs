using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HaarlemFilmFestival.Models
{
    [Table("Cuisines")]
    public class Cuisine
    {
        public int Id { get; set; }
        public string CuisineDescription { get; set; }

        // Koppeling naar Restaurants
        public ICollection<Restaurant> Restaurants { get; set; }
    }
}