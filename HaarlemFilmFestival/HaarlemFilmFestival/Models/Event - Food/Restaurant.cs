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

        // ICollection zorgt ervoor dat je een soort lijst of Collectie kan maken van de elementen van de type Cuisine        
        public ICollection<Cuisine> Cuisines { get; set; }

        //NotMapped zorgt dat er geen nieuwe kolommen in de database gemaakt worden 

        //Deze property is gemaakt om de naam van een restaurant aan te passen
        [NotMapped]
        public string FixedImageName { get { return (RestaurantName.Replace("Mr. & Mrs.", "MrenMrs")); }  }

        //Deze property wordt gebruikt in de view om de cuisine namen te tonen
        [NotMapped]
        public string CuisinesString { get { return (GenerateCuisinesString()); } }

        //hier krijg je een lijst van cuisines terug 
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