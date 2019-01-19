using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HaarlemFilmFestival.Models;
using HaarlemFilmFestival.Repositories;
using HaarlemFilmFestival.ViewModels;

namespace HaarlemFilmFestival.Controllers
{
    public class JazzsController : Controller
    {
        private JazzViewModel viewmodel = new JazzViewModel();
        private IJazzRepository jazzRepository = new JazzRepository();

        // GET: Jazzs
        public ActionResult Index()
        {
            viewmodel = FillViewModel();
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Index(OrderRecord orderrecords)
        {
            if (Session["Orders"] == null)
                Session["Orders"] = new Order();
            Order order = (Order)Session["Orders"];
            orderrecords = new OrderRecord();
            orderrecords.Event_Id = int.Parse(Request.Form["eventid"]);
            orderrecords.RecordAmount = int.Parse(Request.Form["amountOfTickets"]);
            orderrecords.Order_Id = orderrecords.Event_Id;
            orderrecords.Event = jazzRepository.GetJazz(orderrecords.Event_Id);
            if (order.OrderRecords == null)
                order.OrderRecords = new List<OrderRecord>();
            order.OrderRecords.Add(orderrecords);
            if (orderrecords.RecordAmount >= 4)
                orderrecords.TicketType = TicketType.Family;
            else
                orderrecords.TicketType = TicketType.Single;
            Session["Orders"] = order;

            viewmodel = FillViewModel();
            return View(viewmodel);
        }

        public JazzViewModel FillViewModel()
        {
            viewmodel.Jazzs = jazzRepository.GetJazz();
            viewmodel.JazzLocations = jazzRepository.GetJazzLocation();
            //viewmodel.eventsLeft = GetAvailableEvents();
            viewmodel.jazzLeft = getJazzLeft();
            //viewmodel.dates = viewmodel.getDays(viewmodel.eventsLeft);
            //viewmodel.times = viewmodel.getStartTime(viewmodel.eventsLeft);
            viewmodel.Artists = jazzRepository.GetArtists(viewmodel.Jazzs);
            List<DayOfWeek> days; // Kayleigh aangepast
            List<DateTime> starttimes; // Kayleigh aangepast
            List<DateTime> endtimes; // Kayleigh aangepast
            viewmodel.getStarts(viewmodel.jazzLeft, out starttimes, out endtimes, out days); // Kayleigh aangepast
            viewmodel.times = starttimes; // Kayleigh aangepast
            viewmodel.days = days; // Kayleigh aangepast
            return viewmodel;
        }
        public IEnumerable<Jazz> getJazzLeft()
        {
            List<Jazz> left = new List<Jazz>();
            foreach (Jazz jazz in viewmodel.Jazzs)
            {
                if (jazz.Capacity > 0)
                {
                    left.Add(jazz);
                }
                else if (jazz.StartTime.DayOfWeek.ToString() == "Sunday")
                    left.Add(jazz);
            }
            return left;
        }
        //public IEnumerable<Event> GetAvailableEvents()
        //{
        //    IEnumerable<OrderRecord> ordered;
        //    ordered = jazzRepository.GetOrderedEvents();
        //    List<Event> Events = new List<Event>();
        //    foreach (Event Event in viewmodel.Jazzs)
        //    {
        //        int Count = 0;
        //        foreach (OrderRecord orderrecord in ordered)
        //            Count = Count + orderrecord.RecordAmount;
        //        if (Count < Event.Capacity || Event.Capacity == null)
        //            Events.Add(Event);
        //    }
        //    return Events;
        //}
        [HttpGet]
        public PartialViewResult ShowPartialView(string dayOfFestival)
        {
            viewmodel = FillViewModel();
            switch (dayOfFestival)
            {
                case "Thursday":
                    viewmodel.jazzPerDay = jazzRepository.GetJazzPerDay(new DateTime(2018, 7, 26));
                    break;
                case "Friday":
                    viewmodel.jazzPerDay = jazzRepository.GetJazzPerDay(new DateTime(2018, 7, 27));
                    break;
                case "Saturday":
                    viewmodel.jazzPerDay = jazzRepository.GetJazzPerDay(new DateTime(2018, 7, 28));
                    break;
                case "Sunday":
                    viewmodel.jazzPerDay = jazzRepository.GetJazzPerDay(new DateTime(2018, 7, 29));
                    return PartialView("SundayJazzPartialView", viewmodel.jazzPerDay);
                //break;
                default:
                    viewmodel.jazzPerDay = jazzRepository.GetJazzPerDay(new DateTime(2018, 7, 26));
                    break;
            }
            return PartialView("_JazzPartialView", viewmodel.jazzPerDay);
        }
    }
}
