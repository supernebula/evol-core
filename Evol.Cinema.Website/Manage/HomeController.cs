using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Evol.Cinema.Website.Manage
{
    [Area("Manage")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}