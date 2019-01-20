using System.Web.Mvc;


namespace HaarlemFilmFestival.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}