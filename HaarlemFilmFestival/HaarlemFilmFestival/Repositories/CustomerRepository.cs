using HaarlemFilmFestival.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HaarlemFilmFestival.Models;

namespace HaarlemFilmFestival.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private HaarlemFilmFestivalContext db = HaarlemFilmFestivalContext.getInstance();
        public void AddCustomer(Customer customer)
        {
            db.Customers.Add(customer);
            db.SaveChanges();
        }
    }
}