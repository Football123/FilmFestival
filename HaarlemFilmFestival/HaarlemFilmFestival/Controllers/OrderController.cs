using HaarlemFilmFestival.Models;
using HaarlemFilmFestival.Repositories;
using System.Web.Mvc;
using System.Web.Security;

namespace HaarlemFilmFestival.Controllers
{
    public class OrderController : Controller
    {
        private OrderRepository orderRepository = new OrderRepository();
        private CustomerRepository customerRepository = new CustomerRepository();
        private IEventRepository eventRepository = new EventRepository();

        // GET: Tickets
        public ActionResult Index()
        {
            if (Session["Orders"] == null)
                Session["Orders"] = new Order();
            Order order = (Order)Session["Orders"];

            return View();
        }

        public ActionResult Payment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Payment(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                Customer customer = new Customer();
                customer.Name = model.Name;
                customer.LastName = model.LastName;
                customer.DateOfBirth = model.DateOfBirth;
                customer.EmailAddress = model.EmailAddres;
                customerRepository.AddCustomer(customer);

                if (customer != null)
                {
                    FormsAuthentication.SetAuthCookie(customer.EmailAddress, false);
                    return RedirectToAction("Final", "Order");
                }
                else
                    ModelState.AddModelError("register-error", "the username or password provided is incorrect");
            }
            return View(model);
        }

        public ActionResult Final()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Finalize(Order order)
        {
            return View("Final");
        }
    }
}