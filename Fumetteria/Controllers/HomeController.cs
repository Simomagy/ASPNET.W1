using Microsoft.AspNetCore.Mvc;

namespace Fumetteria.Controllers;

public class HomeController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}
