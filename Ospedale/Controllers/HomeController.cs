using Microsoft.AspNetCore.Mvc;

namespace Ospedale.Controllers
{
    public class HomeController : Controller
    {
        // GET
        public IActionResult Home()
        {
            return View();
        }
    }
}
