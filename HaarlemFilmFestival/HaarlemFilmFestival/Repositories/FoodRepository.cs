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
        private HaarlemFilmFestivalContext db = HaarlemFilmFestivalContext.getInstance();
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

        //public Food GetFood(int foodId)
        //{
        //    Food food = db.Foods.Find(foodId);
        //    return food;
        //}

        public IEnumerable<Food> GetFoods()
        {
            IEnumerable<Food> foods = db.Foods;

            return foods;
        }       

        // deze functie aanpassen, eventueel verwijderen.
        public IEnumerable<Food> RestaurantCuisines()
        {
            IEnumerable<Food> foods = GetFoods();

            foreach (Food f in foods)
            {
                RestaurantCuisine resCuisine = new RestaurantCuisine();
                resCuisine = GetRestaurantCuisine(f.Restaurant.Id);
                f.Cuisine = GetCuisine(resCuisine.cuisid);
            }

            return foods;
        }

        public Cuisine GetCuisine(int cuisineId)
        {
            Cuisine c = new Cuisine();

            c = db.Cuisines.Where(xid => xid.Id == cuisineId).FirstOrDefault();

            return c;
        }

        public RestaurantCuisine GetRestaurantCuisine(int restaurantId)
        {
            RestaurantCuisine res = new RestaurantCuisine();

            res = db.RestaurantCuisines.Where(xd => xd.resid == restaurantId).FirstOrDefault();

            return res;
        }

        public IEnumerable<Cuisine> GetCuisines()
        {           
            IEnumerable<Cuisine> cuisines = db.Cuisines;
            
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
            IEnumerable<OrderRecord> ordered = new List<OrderRecord>();
            ordered = db.OrderRecords.ToList();
            foreach (OrderRecord order in ordered)
            {
                Console.WriteLine(order.Event.Id);
            }
            return ordered;
        }
    }
}