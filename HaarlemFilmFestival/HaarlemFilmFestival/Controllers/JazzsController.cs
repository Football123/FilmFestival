using System;
using System.Collections.Generic;
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

        // Deze methode wordt aangeroepen als er op JAZZ in de navigatiebalk geklikt wordt
        public ActionResult Index()
        {
            viewmodel = FillViewModel();
            return View(viewmodel);
        }
        // Deze methode wordt aangeroepen nadat je een aantal kaarten besteld en maakt een order aan van het geselecteerde event.
        [HttpPost]
        public ActionResult Index(OrderRecord orderrecords)
        {
            if (Session["Orders"] == null)
                Session["Orders"] = new Order();
            Order order = (Order)Session["Orders"];
            orderrecords = new OrderRecord();
            orderrecords.Event_Id = int.Parse(Request.Form["eventid"]);
            orderrecords.RecordAmount = int.Parse(Request.Form["amountOfTickets"]);
            // Order_Id wordt tijdelijk gevuld met Event_Id, Order_id wordt overschreven wanneer de order in de database wordt opgeslagen (auto-increment) 
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

            // Refreshen pagina door alle gegevens opnieuw in te laden
            viewmodel = FillViewModel();
            return View(viewmodel);
        }
        // Deze methode vult de ViewModel met de benodigde data voor de views
        public JazzViewModel FillViewModel()
        {
            viewmodel.Jazzs = jazzRepository.GetJazz();
            viewmodel.jazzLeft = getJazzLeft();
            viewmodel.Artists = jazzRepository.GetArtists(viewmodel.Jazzs);
            List<DayOfWeek> days; // Kayleigh aangepast
            List<DateTime> starttimes; // Kayleigh aangepast
            List<DateTime> endtimes; // Kayleigh aangepast
            viewmodel.getStarts(viewmodel.jazzLeft, out starttimes, out endtimes, out days); // Kayleigh aangepast
            viewmodel.times = starttimes; // Kayleigh aangepast
            viewmodel.days = days; // Kayleigh aangepast
            return viewmodel;
        }
        // Deze methode geeft een lijst van alle Jazz-events die nog beschikbaar zijn, staat in de controller omdat er geen database-call nodig is aangezien viewmodel.Jazzs al is gevuld waarmee de nodig beschikbare events opgehaald kunnen worden
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

        // Deze methode geeft de events per datum terug op basis van de geselecteerde datum in de view
        [HttpGet]
        public PartialViewResult ShowPartialView(string dayOfFestival)
        {
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
