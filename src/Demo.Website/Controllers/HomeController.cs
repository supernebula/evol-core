using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Demo.Website.Models;
using System.Text;
using Microsoft.Extensions.Logging;
using NLog;

namespace Demo.Website.Controllers
{
    public class HomeController : Controller
    {
        private NLog.Logger nLogger;

        private ModuleShip _ship;
        private AdminArea _area;
        private ILogger<HomeController> _logger;
        private ILoggerFactory _loggerFactory;
        public HomeController(ModuleShip ship, AdminArea area, ILogger<HomeController> logger, ILoggerFactory loggerFactory)
        {
            _ship = ship;
            _area = area;
            _logger = logger;
            _loggerFactory = loggerFactory;
            nLogger = NLog.LogManager.GetCurrentClassLogger();  
        }

        public IActionResult Index()
        {
            var logger = _loggerFactory.CreateLogger("interf");
            _logger.LogInformation("Test logger info");
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
            _logger.LogWarning("Read Configuration File");
            var subLogger = _loggerFactory.CreateLogger("error");
            subLogger.LogError("Test CreateLogger(error)");
            var sb = new StringBuilder();
            _ship.Modules.ForEach(e => sb.AppendLine($"{e.Name}:{e.Count}"));
            sb.AppendLine("-----------------------------------------------------");
            _area.Areas.ForEach(e => sb.AppendLine($"{e.ParentCode},{e.Code},{e.Name}"));
            nLogger.Error("Test nlogger error");
            var customLogger = nLogger.Factory.GetLogger("custom");
            customLogger.Error("Test custom error");
            return Content(sb.ToString());
        }
    }
}
