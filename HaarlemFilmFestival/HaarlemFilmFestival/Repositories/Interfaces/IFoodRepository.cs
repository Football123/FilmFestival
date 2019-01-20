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
        Cuisine GetCuisine(int cuisineId);        
        IEnumerable<Food> GetFoods();
        IEnumerable<Restaurant> GetRestaurants();
        List<RestaurantCuisine> GetRestaurantCuisinesByRestaurantId(int restaurantId);
        Food GetFood(int Event_Id);
        //IEnumerable<OrderRecord> GetOrderedEvents();
    }
}
