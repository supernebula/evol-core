using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Evol.TMovie.Domain.QueryEntries;
using Evol.Domain.Messaging;
using Evol.TMovie.Domain.QueryEntries.Parameters;
using Evol.TMovie.Domain.Dto;
using Evol.TMovie.Manage.Models;
using Evol.TMovie.Domain.Commands.Dto;
using Evol.TMovie.Domain.Commands;

namespace Evol.TMovie.Manage.Controllers
{
    public class MovieController : Controller
    {

        public MovieController()
        {
        }
        // GET: Movie
        public ActionResult Index()
        {
            return View();
        }


    }
}
