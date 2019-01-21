using System;
using System.Collections.Generic;
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

        // Dit wordt aangeroepen nadat je een item toevoegt aan het winkelmandje.
        // Er wordt dan eerst gekeken of er al een bestaande sessie is, zo niet dan maakt het er eentje aan.
        [HttpPost]
        public ActionResult Index(OrderRecord orderrecords)
        {
            if (Session["Orders"] == null)
                Session["Orders"] = new Order();
            Order order = (Order)Session["Orders"];
            orderrecords = new OrderRecord();
            // Het orderrecord vullen met de gegevens
            orderrecords.Event_Id = int.Parse(Request.Form["eventid"]);
            orderrecords.RecordAmount = int.Parse(Request.Form["amountOfTickets"]);
            orderrecords.Event = historicrepository.GetHistoricById(orderrecords.Event_Id);
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

        public HistoricViewModel FillViewModel()
        {
            viewmodel.historicPerDay = GetHistoricPerDay(new DateTime(2018, 7, 26));
            viewmodel.Historics = historicrepository.GetHistoricEvents();
            viewmodel.languages = GetLanguages();
            viewmodel.Stops = historicrepository.GetStops();
            viewmodel.historicsLeft = getHistoricsLeft();
            // hiermee maak ik drie lege lijstjes aan waarna ik ze vul uit GetStarts()
            List<DayOfWeek> days;
            List<DateTime> starttimes;
            List<DateTime> endtimes;
            viewmodel.getStarts(viewmodel.historicsLeft, out starttimes, out endtimes, out days);
            viewmodel.times = starttimes;
            viewmodel.days = days;

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

        // Dit is om te kijken of de events überhaupt wel beschikbaar zijn. 
        // Hierdoor worden er geen events getoond die niet beschikbaar zijn.
        public IEnumerable<Historic> getHistoricsLeft()
        {
            List<Historic> left = new List<Historic>();
            foreach (Historic historic in viewmodel.Historics)
            {
                if (historic.Capacity > 0)
                    left.Add(historic);
            }
            return left;
        }
    }
}
