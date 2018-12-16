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
            this.eventsLeft = AvailibleEvents();
            this.Foods = foodrepository.GetFoods();
            this.Restaurants = foodrepository.GetRestaurants();
            this.FoodLocations = foodrepository.GetFoodLocation();
            this.Cuisines = GetCuisine();
            this.FoodLeft = getFoodsLeft();
        }

        private IEnumerable<Food> getFoodsLeft()
        {
            AllFood = foodrepository.GetFoods();
            List<Food> left = new List<Food>();
            foreach (Food food in AllFood)
            {
                foreach (Event Event in eventsLeft)
                {
                    if (food.Id.Equals(Event.Id))
                        left.Add(food);
                }
            }
            return left;
        }

        private IEnumerable<Event> AvailibleEvents()
        {
            AllFood = foodrepository.GetFoods();
            IEnumerable<OrderRecord> ordered = foodrepository.GetOrderedEvents();
            List<Event> Events = new List<Event>();
            foreach (Event Event in AllFood)
            {
                int Count = 0;
                foreach (OrderRecord orderrecord in ordered)
                    Count = Count + orderrecord.RecordAmount;
                if (Count < Event.Capacity)
                    Events.Add(Event);
            }
            return Events;
        }

        private IEnumerable<Cuisine> GetCuisine()
        {
            IEnumerable<Cuisine> cuisines = foodrepository.GetCuisines();
            List<Cuisine> list = new List<Cuisine>();
            foreach (Cuisine cuisine in cuisines)
            {
                foreach (Food food in Foods)
                {
                    if (cuisine.Id.Equals(food.Restaurant))
                        list.Add(cuisine);
                }
            }
            return cuisines;
        }

        public IEnumerable<Location> FoodLocations { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }
        public IEnumerable<Food> Foods { get; set; }
        public IEnumerable<Location> Name { get; set; }
        public IEnumerable<Location> LocationDescription { get; set; }
        public IEnumerable<Restaurant> RestaurantName { get; set; }
        public IEnumerable<Restaurant> Stars { get; set; }
        public IEnumerable<Cuisine> Cuisines { get; set; }
        public IEnumerable<Cuisine> CuisineDescription { get; set; }
        public IEnumerable<Event> eventsLeft { get; set; }
        public IEnumerable<Food> FoodLeft { get; set; }
        public IEnumerable<Event> AllFood { get; set; }
    }



}