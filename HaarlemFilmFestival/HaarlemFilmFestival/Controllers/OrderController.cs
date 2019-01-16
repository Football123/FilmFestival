using HaarlemFilmFestival.Models;
using HaarlemFilmFestival.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
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

                    //Session["loggedin_account"] = account;

                    return RedirectToAction("Final", "Order");
                }
                else
                {
                    ModelState.AddModelError("register-error", "the username or password provided is incorrect");
                }

            }         
            return View(model);
        }

        //[HttpPost]
        public ActionResult Final()
        {
            return View();
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

            orderRepository.AddNewBesteling(order);
            return View("Final");
        }
    }
}