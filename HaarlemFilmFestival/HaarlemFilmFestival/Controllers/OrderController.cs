using HaarlemFilmFestival.Models;
using HaarlemFilmFestival.Repositories;
using System;
using System.Linq;
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
        
        // In deze methode wordt onder andere een klant aangemaakt met behulp van een RegisterModel, 
        // de gegevens worden in de view ingevuld en doorgestuurd via het registermodel
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
            // Sessie verwijderen als order in database in opgeslagen
            Session.Clear();
            return View();
        }

        //[HttpPost]
        //public ActionResult Finalize(Order order)
        //{
        //    return View("Final");
        //}
        // Deze methode wordt aangeroepen als er op een kruis wordt geklikt in het winkelmandje via Javascript
        // Deze methode verwijdert het event waarop geklikt wordt door te checken of het id van het orderrecord gelijk is aan het Eventid in de database
        public void DeleteSessie(int id)
        {
            var sessie = (Order)Session["Orders"];
            var orders = sessie.OrderRecords;


            var toDelete = orders.FirstOrDefault(or => or.Event.Id == id);
            if (toDelete == null) throw new Exception("Geef een Event Id mee anders gaat de delete kapot");
            orders.Remove(toDelete);

            if (orders.Count > 0)
            {
                Session["Orders"] = orders;
            }
            else
            {
                Session.Remove("Orders");
            }
        }
    }
}