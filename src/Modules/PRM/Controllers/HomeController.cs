using Microsoft.AspNetCore.Mvc;

namespace NbSites.Areas.Web.PRM.Controllers
{
    [Area("PRM")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
