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

        public JazzViewModel FillViewModel()
        {
            viewmodel.Jazzs = jazzRepository.GetJazz();
            ;
            viewmodel.JazzLocations = jazzRepository.GetJazzLocation();    
            viewmodel.eventsLeft = GetAvailableEvents();
            viewmodel.jazzLeft = getJazzLeft();
            viewmodel.dates = viewmodel.getDays(viewmodel.eventsLeft);
            viewmodel.times = viewmodel.getStartTime(viewmodel.eventsLeft);
            viewmodel.Artists = jazzRepository.GetArtists(viewmodel.Jazzs);
            return viewmodel;
        }
        public IEnumerable<Jazz> getJazzLeft()
        {
            List<Jazz> left = new List<Jazz>();
            foreach (Jazz jazz in viewmodel.Jazzs)
            {
                foreach (Event Event in GetAvailableEvents())
                {
                    if (jazz.Id.Equals(Event.Id))
                        left.Add(jazz);
                }
            }
            return left;
        }
        public IEnumerable<Event> GetAvailableEvents()
        {
            IEnumerable<OrderRecord> ordered;
            ordered = jazzRepository.GetOrderedEvents();
            List<Event> Events = new List<Event>();
            foreach (Event Event in viewmodel.Jazzs)
            {
                int Count = 0;
                foreach (OrderRecord orderrecord in ordered)
                    Count = Count + orderrecord.RecordAmount;
                if (Count < Event.Capacity || Event.Capacity == null)
                    Events.Add(Event);
            }
            return Events;
        }
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
                    break;
                default:
                    viewmodel.jazzPerDay = jazzRepository.GetJazzPerDay(new DateTime(2018, 7, 26));
                    break;
            }
            return PartialView("_JazzPartialView", viewmodel.jazzPerDay);
        }
        [HttpPost]
        public PartialViewResult ShowPartialView(string dayOfFestival, int number)
        {
            return PartialView(dayOfFestival, number);
        }




    }
}
