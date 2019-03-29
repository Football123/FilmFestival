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
        private IFoodRepository foodRepository = new FoodRepository();

        // GET: Foods
        public ActionResult Index()
        {
            FoodViewModel viewmodel = new FoodViewModel();

            IEnumerable<Restaurant> restaurants = foodRepository.GetRestaurants();

            List<Food> filteredFoods = new List<Food>();

            foreach (Restaurant r in restaurants)
            {
                Food food = foodRepository.GetFoodByRestaurant(r);
                filteredFoods.Add(food);
            }

            viewmodel.Foods = filteredFoods;
            viewmodel.Restaurants = restaurants;
            viewmodel.FoodLeft = getFoodsLeft();

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Index(FoodViewModel foodViewModel)
        {
            int foodId = foodRepository.GetFoodId(foodViewModel);
            Food food = foodRepository.GetFood(foodId);

            if (Session["Orders"] == null)
                Session["Orders"] = new Order();

            Order order = (Order)Session["Orders"];
            OrderRecord orderRecord = new OrderRecord();

            if (order.OrderRecords == null)
                order.OrderRecords = new List<OrderRecord>();

            orderRecord.Event = food;
            orderRecord.RecordAmount = foodViewModel.Quantity;
            orderRecord.RecordAmountForKids = 0;

            if (foodViewModel.QuantityForKids != null)
                orderRecord.RecordAmountForKids = (int)foodViewModel.QuantityForKids;

            order.OrderRecords.Add(orderRecord);
            Session["Orders"] = order;

            return RedirectToAction("Index", "Order");
        }


        //public FoodViewModel FillViewModel()
        //{
            //FoodViewModel viewmodel = new FoodViewModel();
            //viewmodel.Restaurants = foodRepository.GetRestaurants();
            //viewmodel.FoodLeft = getFoodsLeft();
            //viewmodel.Foods = foodRepository.GetFoods();


            //return viewmodel;
        //}

        public IEnumerable<Food> getFoodsLeft()
        {
            FoodViewModel viewmodel = new FoodViewModel();
            viewmodel.Foods = foodRepository.GetFoods();

            List<Food> left = new List<Food>();
            foreach (Food food in viewmodel.Foods)
            {
                if (food.Capacity > 0)
                    left.Add(food);
            }
            return left;
        }

       
        //private IEnumerable<Event> GetAvailableEvents()
        //{
        //    IEnumerable<OrderRecord> ordered;            
        //    ordered = foodRepository.GetOrderedEvents();
        //    List<Event> Events = new List<Event>();
        //    foreach (Event Event in viewmodel.Foods)
        //    {
        //        int Count = 0;
        //        foreach (OrderRecord orderrecord in ordered)
        //            Count = Count + orderrecord.RecordAmount;
        //        if (Count < Event.Capacity)
        //            Events.Add(Event);
        //    }
        //    return Events;
        //}


    }
}
