using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Evol.Web.Middlewares
{
    public class VisitAuditMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public VisitAuditMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<VisitAuditMiddleware>();
            _next = next;
        }


        public async Task Invoke(HttpContext context)
        {
            var startTime = DateTime.Now.ToLocalTime().ToString("yyyy/MM/dd hh:mm:ss.fff");
            var sw = new Stopwatch();
            sw.Start();
            await _next.Invoke(context);
            sw.Stop();
            var endTime = DateTime.Now.ToLocalTime().ToString("yyyy/MM/dd hh:mm:ss.fff");
            var Elapsed = sw.ElapsedMilliseconds;

            var sb = new StringBuilder();
            sb.AppendLine($"VISIT Elapsed:{Elapsed} Start:{startTime} End:{endTime} User IP: {context.Connection.RemoteIpAddress}, Request:{context.Request.Protocol}, {context.Request.Method}, {context.Request.Path}, {context.Request.QueryString} , ContentLength {context.Request.ContentLength}, {context.Request.ContentType}");
            sb.AppendLine($"Response: ContentLength {context.Response.ContentLength}, {context.Response.ContentType}");
            _logger.LogInformation(sb.ToString());
        }
    }
}
