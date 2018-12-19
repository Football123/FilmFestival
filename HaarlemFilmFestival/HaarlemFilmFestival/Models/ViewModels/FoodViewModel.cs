using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using HaarlemFilmFestival.Repositories;

namespace HaarlemFilmFestival.Models
{
    public class FoodViewModel : EventViewModel
    {
        private IFoodRepository foodrepository = new FoodRepository();
        private IEventRepository eventRepository = new EventRepository();

        public FoodViewModel()
        {
            this.eventsLeft = AvailableEvents();
            this.Foods = foodrepository.GetFoods();
            this.Restaurants = foodrepository.GetRestaurants();
            this.FoodLocations = foodrepository.GetFoodLocation();
            this.Cuisines = foodrepository.GetCuisines();
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

        private IEnumerable<Event> AvailableEvents()
        {
            IEnumerable<OrderRecord> ordered;
            AllFood = foodrepository.GetFoods();
            ordered = foodrepository.GetOrderedEvents();
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

        public IEnumerable<Location> FoodLocations { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }
        public IEnumerable<Food> Foods { get; set; }
        public IEnumerable<Cuisine> Cuisines { get; set; }
        public IEnumerable<Event> eventsLeft { get; set; }
        public IEnumerable<Food> FoodLeft { get; set; }
        public IEnumerable<Food> AllFood { get; set; }
    }



}