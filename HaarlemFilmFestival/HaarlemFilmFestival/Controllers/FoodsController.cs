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
    public class FoodsController : Controller
    {
        private FoodViewModel viewmodel = new FoodViewModel();
        private IFoodRepository foodRepository = new FoodRepository();

        // GET: Foods
        public ActionResult Index()
        {            
            return View(viewmodel);
        }


    }
}
