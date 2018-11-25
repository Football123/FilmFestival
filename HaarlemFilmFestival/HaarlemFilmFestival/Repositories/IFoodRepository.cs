﻿using HaarlemFilmFestival.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaarlemFilmFestival.Repositories
{
    interface IFoodRepository
    {
        IEnumerable<Food> GetAllFood();
        Food GetFood(int foodId);
        void AddFood(Food food);
        void UpdateFood(Food food);
        void DeleteFood(int foodId);
    }
}