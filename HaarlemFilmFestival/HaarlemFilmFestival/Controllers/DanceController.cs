using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HaarlemFilmFestival.Models;
using HaarlemFilmFestival.Repositories;
using HaarlemFilmFestival.ViewModels;
using HaarlemFilmFestival.Repositories.Interfaces;

namespace HaarlemFilmFestival.Controllers
{
    public class DanceController : Controller
    {
        private DanceViewModel dviewmodel = new DanceViewModel();
        private IDanceRepository danceRepository = new DanceRepository();

        public ActionResult Index()
        {
            return View(dviewmodel);
        }
    }
}