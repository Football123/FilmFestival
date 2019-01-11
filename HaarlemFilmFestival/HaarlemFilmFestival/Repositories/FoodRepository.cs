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

        //hier moet de juiste cuisine lijst opgehaald worden
        public IEnumerable<Restaurant> GetRestaurants()
        {
            IEnumerable<Cuisine> cuisines = new List<Cuisine>();
            cuisines = GetCuisines();
            IEnumerable<Restaurant> restaurants = db.Restaurants;            

            foreach (Restaurant r in restaurants)
            {
                List<RestaurantCuisine> restaurantcuisines = GetRestaurantCuisinesByRestaurantId(r.Id);
                // r.Cuisines = GetCuisinesByRestaurantCuisine(r.Id); 


                foreach (RestaurantCuisine c in restaurantcuisines)
                {
                    r.RestaurantName += "Restaurant: " + c.resid + " Cuisine: " + c.cuisid + "/// ";
                }
                
            }
            // vul restaurant
           
            return restaurants;
        }


        public List<RestaurantCuisine> GetRestaurantCuisinesByRestaurantId(int restaurantId)
        {
            List<RestaurantCuisine> restaurantCuisines = new List<RestaurantCuisine>();

            using (HaarlemFilmFestivalContext db = new HaarlemFilmFestivalContext())
            {
                restaurantCuisines = db.RestaurantCuisines.Where(xid => xid.resid == restaurantId).ToList();
            }


            return restaurantCuisines;
        }

        public ICollection<Cuisine> GetCuisinesByRestaurantCuisine(int restaurantCuisineId)
        {
            return db.Cuisines.Where(xid => xid.Id == restaurantCuisineId).ToList();
        }

        //public ICollection<Cuisine> Cuisines()
        //{
        //    List<Cuisine> cuisines = new List<Cuisine>();
        //    return cuisines;
        //}

        public IEnumerable<Food> GetFoods()
        {
            IEnumerable<Food> foods = db.Foods;

            return foods;
        }
        public IEnumerable<Food> GetPerRestaurant(Restaurant r)
        {
            IEnumerable<Food> events = db.Foods.Where(e => e.Restaurant.Id == r.Id);
            return events;
        }

        // deze functie aanpassen, eventueel verwijderen.
        public IEnumerable<Food> RestaurantCuisines()
        {
            IEnumerable<Food> foods = GetFoods();

            foreach (Food f in foods)
            {
                RestaurantCuisine resCuisine = new RestaurantCuisine();
                resCuisine = GetRestaurantCuisine(f.Restaurant.Id);
                //dit is niet goed want je krijgt elke keer 1 cuisinesoort binnen 
                //terwijl een restaurant meerdere cuisines kan hebben
               // f.Cuisine = GetCuisine(resCuisine.cuisid);
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