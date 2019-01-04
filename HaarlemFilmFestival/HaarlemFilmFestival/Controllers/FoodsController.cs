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
            viewmodel = FillViewModel();
            return View(viewmodel);
        }

        public FoodViewModel FillViewModel()
        {
            viewmodel.eventsLeft = GetAvailableEvents();
            viewmodel.AllFood = foodRepository.GetFoods();
            viewmodel.Foods = foodRepository.RestaurantCuisines();
            viewmodel.Restaurants = foodRepository.GetRestaurants();
            viewmodel.FoodLocations = foodRepository.GetFoodLocation();
            viewmodel.Cuisines = foodRepository.GetCuisines();
            viewmodel.FoodLeft = getFoodsLeft();
            return viewmodel;
        }

        private IEnumerable<Food> getFoodsLeft()
        {
            //AllFood = foodRepository.GetFoods();
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
            foreach (Event Event in viewmodel.AllFood)
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
