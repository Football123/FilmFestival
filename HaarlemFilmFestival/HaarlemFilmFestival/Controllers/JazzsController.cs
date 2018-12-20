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
            // ....
            return View(viewmodel);
        }
        public PartialViewResult ShowPartialView()
        {
            return PartialView("_JazzPartialView", viewmodel);
        }
    }
}
