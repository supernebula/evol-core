using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evol.TMovie.Manage.Controllers
{
    public class StartedController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
