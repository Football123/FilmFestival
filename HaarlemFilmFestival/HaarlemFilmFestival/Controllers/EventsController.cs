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
    public class EventsController : Controller
    {
        private IEventRepository eventRepository = new EventRepository(); 

        // GET: Events
        public ActionResult Index()
        {
            IEnumerable<Event> allEvents = eventRepository.GetAllEvents();
            return View(allEvents);
        }
    }
}
