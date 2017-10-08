using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Evol.TMovie.Domain.QueryEntries;
using Microsoft.AspNetCore.Authorization;

namespace Evol.TMovie.Website.Controllers
{
    public class CinemaController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Schedule()
        {
            return View();
        }


        public IActionResult PickSeat()
        {
            return View();
        }
    }
}