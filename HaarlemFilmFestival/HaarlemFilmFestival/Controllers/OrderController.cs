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
        private IEventRepository eventRepository = new EventRepository();
        // GET: Tickets
        public ActionResult Index()
        {
            IEnumerable<Event> allEvents = eventRepository.GetAllEvents();
            return View(allEvents);
        }
    }
}