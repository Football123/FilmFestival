using System.Collections.Generic;
using System.Web.Mvc;
using HaarlemFilmFestival.Models;
using HaarlemFilmFestival.Repositories;

namespace HaarlemFilmFestival.Controllers
{
    public class EventsController : Controller
    {
        private IEventRepository eventRepository = new EventRepository(); 
        
        public ActionResult Index()
        {
            return View();
        }
    }
}
