using Microsoft.AspNetCore.Mvc;

namespace HairSalonManyToMany.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}