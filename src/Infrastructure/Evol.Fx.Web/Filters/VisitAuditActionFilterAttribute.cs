using Evol.Common.Logging;
using Evol.Fx.Logging.AdapteNLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Web.Mvc;

namespace Evol.Fx.Web.Filters
{
    public class VisitAuditActionFilterAttribute : ActionFilterAttribute, IActionFilter
    {

        private ILoggerFactory _loggerFactory;
        private ILogger _logger;
        private Stopwatch _stopWatch;

        public VisitAuditActionFilterAttribute()
        {
            _loggerFactory = new NLoggerFactory();
            _logger = _loggerFactory.CreateLogger("visit.*");
            _stopWatch = new Stopwatch();
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var path = filterContext.RequestContext.HttpContext.Request.Url.AbsolutePath;
            var logger = _loggerFactory.CreateLogger("visit.*");
        }


        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            _stopWatch.Start();
            base.OnActionExecuting(filterContext);
        }
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            _stopWatch.Stop();
            var elapsed =  _stopWatch.ElapsedMilliseconds;
            _logger.LogTrace("");
            base.OnResultExecuted(filterContext);
        }
    }
}
