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
            return View();
        }

        public HistoricViewModel FillViewModel()
        {
            viewmodel.Historics = historicrepository.GetHistoricEvents();
            viewmodel.languages = GetLanguages();
            viewmodel.Stops = historicrepository.GetStops();
            viewmodel.eventsLeft = GetAvailableEvents();
            viewmodel.historicsLeft = getHistoricsLeft();
            viewmodel.days = viewmodel.getDays(viewmodel.eventsLeft);
            viewmodel.times = viewmodel.getStartTime(viewmodel.eventsLeft);
            return viewmodel;
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
