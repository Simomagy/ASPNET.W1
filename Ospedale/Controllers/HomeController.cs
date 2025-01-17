using Microsoft.AspNetCore.Mvc;
using Ospedale.Models;

namespace Ospedale.Controllers
{
    public class HomeController : Controller
    {
        // GET
        public IActionResult Home()
        {
            return View(DaoMedici.GetInstance().GetTop10());
        }
    }
}
