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
        
        public ActionResult Index()
        {
            //return View(db.Events.ToList());
            return View();
        }

        [HttpPost]
        public ActionResult Index(OrderRecord orderrecords)
        {
            return View();
        }
    }
}
