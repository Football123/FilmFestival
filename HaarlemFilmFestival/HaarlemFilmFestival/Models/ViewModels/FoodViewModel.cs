using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using HaarlemFilmFestival.Repositories;

namespace HaarlemFilmFestival.Models
{
    public class FoodViewModel
    {
        private IFoodRepository foodrepository = new FoodRepository();
        public FoodViewModel()
        {
            this.Foods = foodrepository.GetFoods();
            this.Restaurants = foodrepository.GetRestaurants();
            
        }

        public IEnumerable<Location> Locations { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }
        public double Price { get; set; }
        public OrderRecord RecordAmount { get; set; }
        public double? Discount { get; set; }
        public string Description { get; set; }
        public IEnumerable<Food> Foods { get; set; }
        
    }



}