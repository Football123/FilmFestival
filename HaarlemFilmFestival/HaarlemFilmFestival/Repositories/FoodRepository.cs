using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HaarlemFilmFestival.Models;
using System.Data.Entity;

namespace HaarlemFilmFestival.Repositories
{
    public class FoodRepository : IFoodRepository
    {
        private HaarlemFilmFestivalContext db = new HaarlemFilmFestivalContext();
        private IEventRepository eventrepository = new EventRepository();        

        public IEnumerable<Restaurant> GetRestaurants()
        {
            IEnumerable<Restaurant> Restaurants = db.Restaurants;
            return Restaurants;
        }       

        public IEnumerable<Event> GetAllFood()
        {           
            IEnumerable<Food> Foods = GetFoods();           
            return Foods;
        }

        public Food GetFood(int foodId)
        {
            Food food = db.Foods.Find(foodId);
            return food;
        }

        public IEnumerable<Food> GetFoods()
        {
            IEnumerable<Food> foods = db.Foods;
            return foods;
        }       

        public IEnumerable<Cuisine> GetCuisines(IEnumerable<Food> Foodevents)
        {
            List<Cuisine> cuisines = new List<Cuisine>();
            Food f;
            foreach (Food e in Foodevents)
            {
                
            }           
            return cuisines;
        }

        public IEnumerable<Location> GetFoodLocation()
        {
            List<Location> foodlocations = new List<Location>();
            IEnumerable<Location> locations = eventrepository.GetLocations();
            foreach (Location location in locations)
            {
                foreach (Food foodevent in db.Foods)
                {
                    if (foodevent.Location_Id == location.Id)
                        foodlocations.Add(location);
                }
            }
            return foodlocations;
        }

        public IEnumerable<OrderRecord> GetOrderedEvents()
        {
            return eventrepository.GetOrderedEvents();
        }

        public IEnumerable<Cuisine> GetCuisines()
        {
            throw new NotImplementedException();
        }
    }
}