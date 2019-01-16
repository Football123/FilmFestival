using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HaarlemFilmFestival.Models;
using HaarlemFilmFestival.Repositories;
using HaarlemFilmFestival.ViewModels;

namespace HaarlemFilmFestival.Controllers
{
    public class FoodsController : Controller
    {
        private FoodViewModel viewmodel = new FoodViewModel();
        private IFoodRepository foodRepository = new FoodRepository();

        // GET: Foods
        public ActionResult Index()
        {
            // viewmodel = FillViewModel();
            // return View(viewmodel);
            IEnumerable<Restaurant> restaurants = foodRepository.GetRestaurants();
            return View(restaurants);
        }

        public FoodViewModel FillViewModel()
        {
            Restaurant r = new Restaurant();
            viewmodel.FoodPerDay = GetPerRestaurant(r);
            viewmodel.Foods = foodRepository.GetFoods();
            viewmodel.RestCuis = foodRepository.RestaurantCuisines();
            viewmodel.Restaurants = foodRepository.GetRestaurants();
            viewmodel.FoodLocations = foodRepository.GetFoodLocation();
            viewmodel.Cuisines = foodRepository.GetCuisines();
            viewmodel.FoodLeft = getFoodsLeft();
            viewmodel.eventsLeft = GetAvailableEvents();
            return viewmodel;
        }

        //hier moet juist cuisine lijst opgehaald worden
        private IEnumerable<Food> GetPerRestaurant(Restaurant r)
        {
            IEnumerable<Food> events = foodRepository.GetPerRestaurant(r);
            return events;
        }

        private IEnumerable<Food> getFoodsLeft()
        {
            List<Food> left = new List<Food>();
            foreach (Food food in viewmodel.Foods)
            {
                foreach (Event Event in GetAvailableEvents())
                {
                    if (food.Id.Equals(Event.Id))
                        left.Add(food);
                }
            }
            return left;
        }

        private IEnumerable<Event> GetAvailableEvents()
        {
            IEnumerable<OrderRecord> ordered;            
            ordered = foodRepository.GetOrderedEvents();
            List<Event> Events = new List<Event>();
            foreach (Event Event in viewmodel.Foods)
            {
                int Count = 0;
                foreach (OrderRecord orderrecord in ordered)
                    Count = Count + orderrecord.RecordAmount;
                if (Count < Event.Capacity)
                    Events.Add(Event);
            }
            return Events;
        }


    }
}
