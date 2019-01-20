using HaarlemFilmFestival.Models;
using HaarlemFilmFestival.Repositories;
using System;
using System.Web.Mvc;
using System.Web.Security;

namespace HaarlemFilmFestival.Controllers
{
    public class OrderController : Controller
    {
        private OrderRepository orderRepository = new OrderRepository();
        private CustomerRepository customerRepository = new CustomerRepository();
        private IEventRepository eventRepository = new EventRepository();

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

        // In deze methode word onder andere een klant aangemaakt met behulp van een RegisterModel, de gegevens worden in de view ingevuld en doorgestuurd via het registermodel
        [HttpPost]
        public ActionResult Payment(RegisterModel model, Order order)
        {
            if (ModelState.IsValid)
            {
                Customer customer = new Customer();
                customer.Name = model.Name;
                customer.LastName = model.LastName;
                customer.DateOfBirth = model.DateOfBirth;
                customer.EmailAddress = model.EmailAddres;
                order = (Order)Session["Orders"];
                order.OrderTime = DateTime.Now;
                order.PaymentMethod = model.PaymentMethod.ToString();
                order.Code = 11111;

                if (customer != null && order != null)
                {
                    FormsAuthentication.SetAuthCookie(customer.EmailAddress, false);
                    order.Paid = true;
                    customerRepository.AddCustomer(customer);
                    order.Customer_Id = customer.Id;
                    orderRepository.AddNewOrder(order);
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