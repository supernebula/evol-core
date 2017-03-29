using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Demo.Website.Models;

namespace Demo.Website.Controllers
{
    public class HomeController : Controller
    {

        private SingleConfig _config;
        public HomeController(SingleConfig config)
        {
            _config = config;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult Config()
        {
            return Content(_config.Tick.ToString());
        }
    }
}
