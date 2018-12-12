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
            this.Locations = GetLocations();
            this.Cuisines = GetCuisine();
        }

        private IEnumerable<Location> GetLocations()
        {
            List<Location> locations = new List<Location>();
            foreach (Location location in Locations)
            {
                foreach (Food food in Foods)
                {
                    if (location.Id.Equals(food.Location_Id))
                        locations.Add(location); 
                }
            }
            return locations;
        }

        private IEnumerable<Event> AvailibleEvents()
        {
            IEnumerable<OrderRecord> ordered = foodrepository.GetOrderedEvents();
            List<Event> Events = new List<Event>();
            foreach (Event Event in this.Foods)
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

        public IEnumerable<Location> Locations { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }
        public IEnumerable<Food> Foods { get; set; }
        public IEnumerable<Location> Name { get; set; }
        public IEnumerable<Location> LocationDescription { get; set; }
        public IEnumerable<Restaurant> RestaurantName { get; set; }
        public IEnumerable<Restaurant> Stars { get; set; }
        public IEnumerable<Cuisine> Cuisines { get; set; }
        public IEnumerable<Cuisine> CuisineDescription { get; set; }
        public IEnumerable<Event> eventsLeft { get; set; }
    }



}