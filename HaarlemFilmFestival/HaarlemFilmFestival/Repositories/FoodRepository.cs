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
        private HaarlemFilmFestivalContext db = new HaarlemFilmFestivalContext();
        public void AddFood(Food food)
        {
            db.Foods.Add(food);
            db.SaveChanges();
        }

        public void DeleteFood(int foodId)
        {
            Food food = db.Foods.Find(foodId);
            db.Foods.Remove(food);
            db.SaveChanges();
        }

        public IEnumerable<Food> GetAllFood()
        {
            IEnumerable<Food> foods = db.Foods;
            return foods;
        }

        public Food GetFood(int foodId)
        {
            Food food = db.Foods.Find(foodId);
            return food;
        }

        public void UpdateFood(Food food)
        {
            db.Entry(food).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}