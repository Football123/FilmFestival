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
            //haal alle dubele en overbodige code eruit
            List<Food> foods = new List<Food>();

            IEnumerable<Restaurant> restaurants = foodRepository.GetRestaurants();
            //overbodig
            viewmodel = FillViewModel();
            IEnumerable<Food> getFoods = foodRepository.GetFoods() ;
            List<Food> foodsFromViewModel = new List<Food>();
            foreach  (Food food in getFoods)
            {
                foodsFromViewModel.Add(food);
            }

            //let op de namen
            //probeer restaurantIndexMultiplier op een ander manier op te lossen
            int teller = 0;
            int restaurantIndexMultiplier = 12;
            foreach (Restaurant r in restaurants)
            {
                Food food = new Food();
                food.Restaurant = r;
                food.Price = foodsFromViewModel[(teller * restaurantIndexMultiplier)].Price;
                food.Discount = foodsFromViewModel[(teller * restaurantIndexMultiplier)].Discount;
                foods.Add(food);
                teller++;
            }

            //het liefst geen ViewBag gebruiken
            ViewBag.foodz = foods;

            
            return View(viewmodel);
        }

        [HttpPost]
        //deze moet afgemaakt worden voor het winkelmandje
        public ActionResult Index(OrderRecord orderrecords)
        {
            if (Session["Orders"] == null)
                Session["Orders"] = new Order();
            Order order = (Order)Session["Orders"];
            orderrecords = new OrderRecord();
            orderrecords.Event_Id = int.Parse(Request.Form["eventid"]);
            orderrecords.RecordAmount = int.Parse(Request.Form["amountOfTickets"]);
            //orderrecords.RecordAmount = int.Parse(Request.Form["amountOfTickets1"]);
            //orderrecords.Event.StartTime = int.Parse(Request.Form["startOfTickets"]);
            orderrecords.Order_Id = orderrecords.Event_Id;
            orderrecords.Event = foodRepository.GetFood(orderrecords.Event_Id);
            if (order.OrderRecords == null)
                order.OrderRecords = new List<OrderRecord>();
            order.OrderRecords.Add(orderrecords);            
            Session["Orders"] = order;

            viewmodel = FillViewModel();
            return View(viewmodel);
        }

        public FoodViewModel FillViewModel()
        {
            viewmodel.Restaurants = foodRepository.GetRestaurants();
            viewmodel.FoodLeft = foodRepository.GetAvailableFoods();


            return viewmodel;
        }
        
        public IEnumerable<Food> GetFoodsLeft()
        {
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
