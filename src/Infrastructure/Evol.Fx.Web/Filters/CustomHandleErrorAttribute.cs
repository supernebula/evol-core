using Evol.Common.Logging;
using Evol.Fx.Logging.AdapteNLog;
using System.Web.Mvc;

namespace Evol.Fx.Web.Filters
{
    /// <summary>
    /// 自动MVC异常过滤器，记录异常到日志（根据nlog.config配置 记录到文本或数据库）
    /// </summary>
    public class CustomHandleErrorAttribute : HandleErrorAttribute
    {
        private ILoggerFactory _loggerFactory;
        private ILogger _logger;

        public CustomHandleErrorAttribute()
        {
            _loggerFactory = new NLoggerFactory();
            _logger = _loggerFactory.CreateLogger("visit.*");
        }

        public override void OnException(ExceptionContext filterContext)
        {
            ///ex.api <see cref="nlog.config"/>
            var logger = _loggerFactory.CreateLogger("ex.mvc");
            var request = filterContext.RequestContext.HttpContext.Request;

            var httpMethod = request.ServerVariables.Get("Request_Method").ToString();
            var requestUri = request.Url.AbsoluteUri;
            var requestPath = request.Url.LocalPath;

            logger.LogError(filterContext.Exception, filterContext.Exception.Message, requestUri, requestPath);
            base.OnException(filterContext);
        }
    }
}
