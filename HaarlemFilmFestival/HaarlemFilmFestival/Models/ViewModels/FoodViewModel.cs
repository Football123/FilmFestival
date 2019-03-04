using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using HaarlemFilmFestival.Repositories;
using HaarlemFilmFestival.Controllers;

namespace HaarlemFilmFestival.Models
{
    public class FoodViewModel : EventViewModel
    {        
        
        public FoodViewModel()
        {
           
        }               
        
        public IEnumerable<Restaurant> Restaurants { get; set; }
        public IEnumerable<Food> Foods { get; set; }
        public IEnumerable<Food> FoodLeft { get; set; }
        //public IEnumerable<Food> RestCuis { get; set; }   

        //public DateTime StartTime { get { return (new DateTime(2018, 2, 19)); } set { } }
        //public double Price { get; set; }
        //public double? Discount { get; set; }
        //public string Description { get; set; }

        public OrderRecord OrderRecord { get; set; }
        public int Restaurant_Id { get; set; } 
        public string Description { get; set; }
        public DateTime Days { get; set; }
        public DateTime Times { get; set; }
    }



}