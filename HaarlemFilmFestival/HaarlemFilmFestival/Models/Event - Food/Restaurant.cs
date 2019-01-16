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

        // Koppeling Keuken en dit moet gebruikt worden in de foodcontroller (en foodviewmodel)
        public ICollection<Cuisine> Cuisines { get; set; }

        [NotMapped]
        public string FixedImageName { get { return (RestaurantName.Replace("Mr. & Mrs.", "MrenMrs")); }  }

        [NotMapped]
        public string CuisinesString { get { return (GenerateCuisinesString()); } }

        public string GenerateCuisinesString()
        {
            int cuisinesLength = Cuisines.Count;
            int teller = 1;
            string cuisinesStr = "";

            foreach (Cuisine c in Cuisines)
            {
                if (teller !=  cuisinesLength)
                {
                    cuisinesStr += c.CuisineDescription + ", ";
                }
                else
                {
                    cuisinesStr += c.CuisineDescription;
                }
                teller++;
            }
            return cuisinesStr;
        }
    }
}