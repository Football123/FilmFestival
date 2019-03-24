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

        public OrderRecord OrderRecord { get; set; }
        public int Restaurant_Id { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public int? QuantityForKids { get; set; }
        public int Day { get; set; }
        public int Time { get; set; }
        public DateTime StartTime { get { return GetStartTime(Day, Time); } }

        //public DateTime FixedStartTime
        //{
        //    get
        //    {
        //        return (DateTime.ParseExact("2018-07-01 14:40:52,531", "yyyy-MM-dd HH:mm:ss,fff",
        //System.Globalization.CultureInfo.InvariantCulture));
        //    }
        //}

        private DateTime GetStartTime(int day, int time)
        {
            day += 26;
            switch (time)
            {
                case 0:
                    time = 17;
                    break;
                case 1:
                    time = 19;
                    break;
                case 2:
                    time = 21;
                    break;
                default:
                    time = 17;
                    break;
            }
            DateTime startTime = new DateTime(2018, 7, day, time, 0, 0);
            return startTime;

        }
    }



}