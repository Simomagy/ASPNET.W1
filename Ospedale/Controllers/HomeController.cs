using Microsoft.AspNetCore.Mvc;

namespace Ospedale.Controllers
{
    public class HomeController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}
