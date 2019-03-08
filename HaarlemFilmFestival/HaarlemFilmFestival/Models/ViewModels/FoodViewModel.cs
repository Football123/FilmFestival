using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using HaarlemFilmFestival.Repositories;
using HaarlemFilmFestival.Controllers;

namespace HaarlemFilmFestival.Models
{
    public class FoodViewModel : EventViewModel
    {        
        
        public FoodViewModel()
        {
           
        }               
        
        public IEnumerable<Restaurant> Restaurants { get; set; }
        public IEnumerable<Food> Foods { get; set; }
        public IEnumerable<Food> FoodLeft { get; set; }
        //public IEnumerable<Food> RestCuis { get; set; }   

        //public DateTime StartTime { get { return (new DateTime(2018, 2, 19)); } set { } }
        //public double Price { get; set; }
        //public double? Discount { get; set; }
        //public string Description { get; set; }

        public OrderRecord OrderRecord { get; set; }
        public int Restaurant_Id { get; set; } 
        public string Description { get; set; }
        public int Days { get; set; }
        public int Times { get; set; }
        public DateTime StartTime { get{ return GetStartTime(Days, Times); } }

        private DateTime GetStartTime(int day, int time)
        {
            day += 25;
            switch (time)
            {
                case 1:
                    time = 17;
                    break;
                case 2:
                    time = 19;
                    break;
                case 3:
                    time = 21;
                    break;
                default:
                    time = 17;
                    break;
            }
            DateTime startTime = new DateTime(2018,7,day,time,0,0);
            return startTime;
            
        }
    }



}