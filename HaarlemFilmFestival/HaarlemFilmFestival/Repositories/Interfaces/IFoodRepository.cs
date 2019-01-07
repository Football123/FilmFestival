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
        IEnumerable<Food> RestaurantCuisines();
        Cuisine GetCuisine(int cuisineId);
        RestaurantCuisine GetRestaurantCuisine(int restaurantId);
        IEnumerable<Location> GetFoodLocation();
        IEnumerable<OrderRecord> GetOrderedEvents();
        IEnumerable<Food> GetPerRestaurant(Restaurant r);
        //IEnumerable<Event> GetAllFood();
        IEnumerable<Food> GetFoods();
        IEnumerable<Restaurant> GetRestaurants();
       // Food GetFood(int foodId);
       
    }
}
