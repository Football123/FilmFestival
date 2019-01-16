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

namespace HaarlemFilmFestival.Controllers
{
    public class HistoricsController : Controller
    {
        private IHistoricRepository historicrepository = new HistoricRepository();
        public HistoricViewModel viewmodel = new HistoricViewModel();

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
            orderrecords.RecordAmount = int.Parse(Request.Form["amountOfTickets"]);
            //    orderrecords.Event = historicrepository.GetByDateAndLang(int.Parse(Request.Form["time"]), int.Parse(Request.Form["day"]), (Taal)(int.Parse(Request.Form["lang"])));
            //orderrecords.Event_Id = orderrecords.Event.Id;
            if (order.OrderRecords == null)
                order.OrderRecords = new List<OrderRecord>();
            order.OrderRecords.Add(orderrecords);
            if (orderrecords.RecordAmount >= 4)
                orderrecords.TicketType = TicketType.Family;
            else
                orderrecords.TicketType = TicketType.Single;
            Session["Orders"] = order;

            return View(viewmodel);
        }

        public ActionResult PlaceOrder(string id)
        {
            Historic historic = historicrepository.GetHistoricEvent(Int32.Parse(id));
            return View(historic);
        }

        public HistoricViewModel FillViewModel()
        {
            viewmodel.historicPerDay = GetHistoricPerDay(new DateTime(2018, 7, 26));
            viewmodel.StartTimes = historicrepository.GetStartTimes();
            viewmodel.Historics = historicrepository.GetHistoricEvents();
            viewmodel.languages = GetLanguages();
            viewmodel.Stops = historicrepository.GetStops();
            viewmodel.eventsLeft = GetAvailableEvents();
            viewmodel.historicsLeft = getHistoricsLeft();
            viewmodel.dates = viewmodel.getDays(viewmodel.eventsLeft);
            viewmodel.times = viewmodel.getStartTime(viewmodel.eventsLeft);
            
            return viewmodel;
        }

        public PartialViewResult HistoricPartialView(string day)
        {
            viewmodel = FillViewModel();
            switch (day)
            {
                case "Thursday":
                    viewmodel.historicPerDay = GetHistoricPerDay(new DateTime(2018, 7, 26));
                    break;
                case "Friday":
                    viewmodel.historicPerDay = GetHistoricPerDay(new DateTime(2018, 7, 27));
                    break;
                case "Saturday":
                    viewmodel.historicPerDay = GetHistoricPerDay(new DateTime(2018, 7, 28));
                    break;
                case "Sunday":
                    viewmodel.historicPerDay = GetHistoricPerDay(new DateTime(2018, 7, 29));
                    break;
                default:
                    viewmodel.historicPerDay = GetHistoricPerDay(new DateTime(2018, 7, 26));
                    break;
            }
            return PartialView("_HistoricPartialView", viewmodel);
        }

        public IEnumerable<Historic> GetHistoricPerDay(DateTime day)
        {
            IEnumerable<Historic> events = historicrepository.GetHistoricPerDay(day);
            return events;
        }

        public IEnumerable<Historic> GetPerTime(DateTime time)
        {
            IEnumerable<Historic> events = historicrepository.GetHistoricPerTime(time);
            return events;
        }

        public IEnumerable<Historic> GetPerDayAndTime(DateTime daytime)
        {
            IEnumerable<Historic> events = historicrepository.GetPerDayAndTime(daytime);
            return events;
        }

        public IEnumerable<Historic> getHistoricsLeft()
        {
            List<Historic> left = new List<Historic>();
            foreach (Historic historic in viewmodel.Historics)
            {
                foreach (Event Event in GetAvailableEvents())
                {
                    if (historic.Id.Equals(Event.Id))
                        left.Add(historic);
                }
            }
            return left;
        }

        public IEnumerable<Language> GetLanguages()
        {
            List<Language> languages = new List<Language>();
            foreach (Historic historic in getHistoricsLeft())
            {
                if (!languages.Contains(historic.Languages))
                    languages.Add(historic.Languages);
            }
            return languages;
        }

        public IEnumerable<Event> GetAvailableEvents()
        {
            IEnumerable<OrderRecord> ordered;
            ordered = historicrepository.GetOrderedEvents();
            List<Event> Events = new List<Event>();
            foreach (Event Event in viewmodel.Historics)
            {
                int Count = 0;
                foreach (OrderRecord orderrecord in ordered)
                    Count = Count + orderrecord.RecordAmount;
                if (Count < Event.Capacity)
                    Events.Add(Event);
            }
            return Events;
        }
    }
}
