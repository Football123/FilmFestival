using HaarlemFilmFestival.Models;
using HaarlemFilmFestival.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HaarlemFilmFestival.Controllers
{
    public class OrderController : Controller
    {
        private OrderRepository orderrepository = new OrderRepository();
        private IEventRepository eventRepository = new EventRepository();

        // GET: Tickets
        public ActionResult Index(int id)
        {
            if (Session["Orders"] == null)
            {
                Session["Orders"] = new Order();
            }
            Order order = (Order)Session["Orders"];
            //IEnumerable<Event> events = eventRepository.GetEvent(id);
            IEnumerable<Event> events = eventRepository.GetAllEvents();
            return View(events);
        }
        
        [HttpPost]
        public ActionResult Payment()
        {
            return View("Payment");
        }

        [HttpPost]
        public ActionResult Final()
        {
            return View("Final");
        }

        [HttpPost]
        public ActionResult Finalize(Order order)
        {
            Customer customer = new Customer();
            String[] fullname = Request.Form["fullname"].Split(new char[0]);
            String email = Request.Form["email"];
          //  DateTime dateofbirth = Request.Form["dateofbirth"];
            customer.Name = fullname.First();
            customer.LastName = fullname.Last();
            customer.EmailAddress = email;
          //  customer.DateOfBirth = dateofbirth;

            order = (Order)Session["Orders"];
            order.OrderTime = DateTime.Now;
            order.Customer = customer;

            orderrepository.AddNewBesteling(order);
            return View("Final");
        }
    }
}