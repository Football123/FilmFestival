using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HaarlemFilmFestival.Controllers
{
    public class DanceController : Controller
    {
        // GET: Dance
        public ActionResult Index()
        {
            return View();
        }
    }
}