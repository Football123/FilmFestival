using HaarlemFilmFestival.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaarlemFilmFestival.Repositories.Interfaces
{
    interface ICustomerRepository
    {
        void AddCustomer(Customer customer);
    }
}