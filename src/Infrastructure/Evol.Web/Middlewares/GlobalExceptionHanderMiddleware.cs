using Evol.Util.Serialization;
using Evol.Web.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
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
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            _logger.LogError(new EventId(Thread.CurrentThread.ManagedThreadId), ex, ex.Message);

            if (context.Response.HasStarted)
            {
                _logger.LogWarning("The response has already started, the error handler will not be executed.");;
            }

            context.Response.Clear();

            //InputError
            //context.Response.Clear();   
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.Response.OnStarting(ClearCacheHeaders, context.Response);
            context.Response.ContentType = context.Request.Headers["Accept"];
            if (context.Response.ContentType.ToLower() == "application/xml;charset=utf-8")
                return context.Response.WriteAsync(XmlUtil.Serialize(ex));
            else
            {
                context.Response.ContentType = "application/json;charset=utf-8";
                var inex = (InputError)ex;
                var content = JsonUtil.Serialize(inex);
                return context.Response.WriteAsync(ex.Message);
            }

        }

        private Task ClearCacheHeaders(object state)
        {
            var response = (HttpResponse)state;
            response.Headers[HeaderNames.CacheControl] = "no-cache";
            response.Headers[HeaderNames.Pragma] = "no-cache";
            response.Headers[HeaderNames.Expires] = "-1";
            response.Headers.Remove(HeaderNames.ETag);
            return Task.CompletedTask;
        }

    }
}


