using Evol.Common.Logging;
using Evol.Fx.Logging.AdapteNLog;
using System.Configuration;
using System.Diagnostics;
using System.Web.Mvc;

namespace Evol.Fx.Web.Filters
{
    /// <summary>
    /// MVC访问审计日志，记录异常到日志（根据nlog.config配置 记录到文本或数据库）
    /// </summary>
    public class VisitAuditActionFilterAttribute : ActionFilterAttribute, IActionFilter
    {

        private ILoggerFactory _loggerFactory;
        private ILogger _logger;
        private Stopwatch _stopWatch;

        public VisitAuditActionFilterAttribute()
        {
            _loggerFactory = new NLoggerFactory();
            _logger = _loggerFactory.CreateLogger("visit.*");
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            _stopWatch = new Stopwatch();
            _stopWatch.Start();
            base.OnActionExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            _stopWatch.Stop();
            var elapsed = _stopWatch.ElapsedMilliseconds;
            _stopWatch.Reset();

            var request = filterContext.RequestContext.HttpContext.Request;
            var lbAppId = ConfigurationManager.AppSettings["LBAppId"];
            var hostAddr = request.ServerVariables.Get("Local_Addr").ToString();
            var hostName = request.ServerVariables.Get("Server_Name").ToString();
            var remoteAddr = request.ServerVariables.Get("Remote_Addr").ToString();
            var httpMethod = request.ServerVariables.Get("Request_Method").ToString();
            var httpVersion = request.ServerVariables.Get("Server_Protocol").ToString();
            var requestUri = request.Url.AbsoluteUri;
            var requestPath = request.Url.LocalPath;
            var UserAgent = request.ServerVariables.Get("HTTP_USER_AGENT").ToString();

            _logger.LogVisit(hostAddr, hostName, remoteAddr, requestPath, httpMethod, httpVersion, requestUri, UserAgent, elapsed, lbAppId);
        }



        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {

            base.OnResultExecuted(filterContext);
        }
    }
}
