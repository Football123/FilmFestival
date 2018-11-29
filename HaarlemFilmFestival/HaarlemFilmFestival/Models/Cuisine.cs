using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaarlemFilmFestival.Models
{
    public class Cuisine
    {
        public int Id { get; set; }
        public string CuisineDescription { get; set; }

        // Koppeling naar Restaurants
        public ICollection<Restaurant> Restaurants { get; set; }
    }
}