using Evol.Util.Serialization;
using Evol.Web.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Evol.Web.Middlewares
{
    public class GlobalExceptionHanderMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public GlobalExceptionHanderMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger("unHandledException");
            _next = next;
        }


        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex).ConfigureAwait(false);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            _logger.LogError(new EventId(Thread.CurrentThread.ManagedThreadId), ex, ex.Message);

            if (ex is InputError)
            {
                context.Response.Clear();   
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Response.ContentType = context.Request.Headers["Accept"];
                if (context.Response.ContentType.ToLower() == "application/xml")
                    await context.Response.WriteAsync(XmlUtil.Serialize(ex)).ConfigureAwait(false);
                else 
                {
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync(JsonUtil.Serialize(ex)).ConfigureAwait(false);
                }
            }
        }

    }
}
