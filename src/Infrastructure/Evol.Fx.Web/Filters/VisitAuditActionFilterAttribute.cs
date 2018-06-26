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
            var request = filterContext.RequestContext.HttpContext.Request;

            var hostAddr = request.ServerVariables.Get("Local_Addr").ToString();
            var hostName = request.ServerVariables.Get("Server_Name").ToString();
            var remoteAddr = request.ServerVariables.Get("Remote_Addr").ToString();
            var httpReferer = request.ServerVariables.Get("Http_Referer").ToString();
            var httpMethod = request.ServerVariables.Get("Http_Referer").ToString();
            var httpVersion = request.ServerVariables.Get("Http_Referer").ToString();
            var requestUri = request.Url.AbsoluteUri;
            var UserAgent = request.ServerVariables.Get("HTTP_USER_AGENT").ToString();

            _logger.LogVisit(hostAddr, hostName, remoteAddr, httpReferer,httpMethod, httpVersion, requestUri, UserAgent, elapsed);
            base.OnResultExecuted(filterContext);
        }
    }
}
