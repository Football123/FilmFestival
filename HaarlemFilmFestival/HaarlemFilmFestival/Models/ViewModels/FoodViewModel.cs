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
        //public IEnumerable<Food> Foods { get; set; }
        public IEnumerable<Food> FoodLeft { get; set; }
        //public IEnumerable<Food> RestCuis { get; set; }     
    }



}