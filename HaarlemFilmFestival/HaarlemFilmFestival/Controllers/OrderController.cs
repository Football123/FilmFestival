using HaarlemFilmFestival.Models;
using HaarlemFilmFestival.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace HaarlemFilmFestival.Controllers
{
    public class OrderController : Controller
    {
        private OrderRepository orderrepository = new OrderRepository();
        private IEventRepository eventRepository = new EventRepository();

        // GET: Tickets
        public ActionResult Index(int? id)
        {            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jazz jazzevent = (Jazz) eventRepository.GetEvent((int)id);
            if (jazzevent == null)
            {
                return HttpNotFound();
            }

            if (Session["Orders"] == null)
            {
                Session["Orders"] = new Order();
            }
            Order order = (Order)Session["Orders"];

            return View(jazzevent);
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