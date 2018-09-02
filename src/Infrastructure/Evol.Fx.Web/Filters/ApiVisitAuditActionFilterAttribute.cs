using Evol.Common.Logging;
using Evol.Fx.Logging.AdapteNLog;
using System;
using System.Configuration;
using System.Diagnostics;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Evol.Fx.Web.Filters
{
    /// <summary>
    /// WebAPI访问审计日志，记录异常到日志（根据nlog.config配置 记录到文本或数据库）
    /// </summary>
    public class ApiVisitAuditActionFilterAttribute : System.Web.Http.Filters.ActionFilterAttribute
    {
        private ILoggerFactory _loggerFactory;
        private ILogger _logger;
        Stopwatch _stopWatch2;

        public ApiVisitAuditActionFilterAttribute()
        {
            _loggerFactory = new NLoggerFactory();
            _logger = _loggerFactory.CreateLogger("visit.*");
            _stopWatch2 = new Stopwatch();

        }



        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            _stopWatch2.Start();
            base.OnActionExecuting(actionContext);
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            _stopWatch2.Stop();
            var elapsed = _stopWatch2.ElapsedMilliseconds;
            _stopWatch2.Reset();
            var request = actionExecutedContext.Request;

            var lbAppId = ConfigurationManager.AppSettings["LBAppId"];
            var hostAddr = GetRequestHeaderValue(request, "Local_Addr") ?? "";
            var hostName = GetRequestHeaderValue(request, "Server_Name") ?? "";
            var remoteAddr = GetRequestHeaderValue(request, "Remote_Addr") ?? "";
            var httpMethod = GetRequestHeaderValue(request, "Request_Method") ?? "";
            var httpVersion = GetRequestHeaderValue(request, "Server_Protocol") ?? "";
            var requestUri = request.RequestUri.AbsoluteUri;
            var requestPath = request.RequestUri.LocalPath;
            var UserAgent = GetRequestHeaderValue(request, "HTTP_USER_AGENT") ?? "";

            _logger.LogVisit(hostAddr, hostName, remoteAddr, requestPath, httpMethod, httpVersion, requestUri, UserAgent, elapsed, lbAppId);
            base.OnActionExecuted(actionExecutedContext);
        }

        public string GetRequestHeaderValue(HttpRequestMessage request, string headerKey)
        {
            const string HttpContext = "MS_HttpContext";
            const string RemoteEndpointMessage = "System.ServiceModel.Channels.RemoteEndpointMessageProperty";
            const string OwinContext = "MS_OwinContext";

            // Web-hosting. Needs reference to System.Web.dll
            if (request.Properties.ContainsKey(HttpContext))
            {
                dynamic ctx = request.Properties[HttpContext];
                if (ctx != null)
                {
                    var headerValue = ctx.Request.ServerVariables.Get(headerKey).ToString();
                    return headerValue;
                }
            }

            // Self-hosting. Needs reference to System.ServiceModel.dll. 
            if (request.Properties.ContainsKey(RemoteEndpointMessage))
            {
                dynamic remoteEndpoint = request.Properties[RemoteEndpointMessage];
                if (remoteEndpoint != null)
                {
                    throw new NotImplementedException();
                    //return remoteEndpoint;
                }
            }

            // Self-hosting using Owin. Needs reference to Microsoft.Owin.dll. 
            if (request.Properties.ContainsKey(OwinContext))
            {
                dynamic owinContext = request.Properties[OwinContext];
                if (owinContext != null)
                {
                    throw new NotImplementedException();
                    //return owinContext.Request.RemoteIpAddress;
                }
            }

            return null;

        }

    }
}

