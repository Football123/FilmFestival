using HaarlemFilmFestival.Models;

namespace HaarlemFilmFestival.Repositories.Interfaces
{
    interface ICustomerRepository
    {
        int AddCustomer(Customer customer);
    }
}