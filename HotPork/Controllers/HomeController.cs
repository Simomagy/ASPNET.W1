﻿using Microsoft.AspNetCore.Mvc;

namespace HotPork.Controllers;

public class HomeController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}