using HaarlemFilmFestival.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaarlemFilmFestival.Repositories
{
    interface IFoodRepository
    {
        IEnumerable<Cuisine> GetCuisines();
        IEnumerable<Location> GetFoodLocation();
        IEnumerable<OrderRecord> GetOrderedEvents();
        IEnumerable<Event> GetAllFood();
        IEnumerable<Food> GetFoods();
        IEnumerable<Restaurant> GetRestaurants();
        Food GetFood(int foodId);
       
    }
}
