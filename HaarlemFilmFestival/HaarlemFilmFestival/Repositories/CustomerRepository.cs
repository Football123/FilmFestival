using HaarlemFilmFestival.Repositories.Interfaces;
using HaarlemFilmFestival.Models;

namespace HaarlemFilmFestival.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private HaarlemFilmFestivalContext db = HaarlemFilmFestivalContext.getInstance();
        public int AddCustomer(Customer customer)
        {
            db.Customers.Add(customer);
            db.SaveChanges();
            return customer.Id;
        }
    }
}