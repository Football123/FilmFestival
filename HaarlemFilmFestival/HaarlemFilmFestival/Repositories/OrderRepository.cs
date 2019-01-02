using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HaarlemFilmFestival.Models;

namespace HaarlemFilmFestival.Repositories
{
    public class OrderRepository
    {
        private HaarlemFilmFestivalContext db = HaarlemFilmFestivalContext.getInstance();

        public void AddNewBesteling(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
        }
    }
}