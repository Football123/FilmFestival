﻿using System;
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

        //geef een lijst terug van alle Restaurant_Ids in RestaurantCuisine
        public List<RestaurantCuisine> GetRestaurantCuisinesByRestaurantId(int restaurantId)
        {
            List<RestaurantCuisine> restaurantCuisines = new List<RestaurantCuisine>();

            using (HaarlemFilmFestivalContext db = new HaarlemFilmFestivalContext())
            {
                restaurantCuisines = db.RestaurantCuisines.Where(rcid => rcid.resid == restaurantId).ToList();
            }


            return restaurantCuisines;
        }

        //Geef de restaurants terug met de juiste Cuisine_Id
        public IEnumerable<Restaurant> GetRestaurants()
        {
            IEnumerable<Restaurant> restaurants = db.Restaurants;            


            foreach (Restaurant r in restaurants)
            {
                List<RestaurantCuisine> restaurantcuisines = GetRestaurantCuisinesByRestaurantId(r.Id);
                List<Cuisine> cuisines = new List<Cuisine>();


                foreach (RestaurantCuisine rc in restaurantcuisines)
                {
                    Cuisine c = GetCuisine(rc.cuisid);
                    
                    cuisines.Add(c);
                }
                r.Cuisines = cuisines;
                
            }
           
            return restaurants;
        }
        
        //Haal alles op van de Food tabel
        public IEnumerable<Food> GetFoods()
        {
            IEnumerable<Food> foods = db.Foods;

            return foods;
        }

        //Laad de Food op basis van de Food_Id
        public Food GetFood(int Event_Id)
        {
            Food item = db.Foods.Where(a => a.Id == Event_Id).SingleOrDefault();
            return item;
        }
                
        //Laad de Cuisine op basis van de Cuisine_Id
        public Cuisine GetCuisine(int cuisineId)
        {
            Cuisine c = db.Cuisines.Where(cid => cid.Id == cuisineId).FirstOrDefault();

            return c;
        }       
       
        //public IEnumerable<OrderRecord> GetOrderedEvents()
        //{
        //    IEnumerable<OrderRecord> ordered = new List<OrderRecord>();
        //    ordered = db.OrderRecords.ToList();
        //    foreach (OrderRecord order in ordered)
        //    {
        //        Console.WriteLine(order.Event.Id);
        //    }
        //    return ordered;
        //}
    }
}