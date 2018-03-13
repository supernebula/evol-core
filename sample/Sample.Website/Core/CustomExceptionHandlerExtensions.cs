using Evol.Common.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Website.Core
{
    public static class CustomExceptionHandlerExtensions
    {
        //
        // 摘要:
        //     Adds a middleware to the pipeline that will catch exceptions, log them, and re-execute
        //     the request in an alternate pipeline. The request will not be re-executed if
        //     the response has already started.
        //
        // 参数:
        //   app:
        [Obsolete("未完成...")]
        public static IApplicationBuilder UseCanContinueExceptionHandler(this IApplicationBuilder app)
        {
            RequestDelegate handle = async (context) =>  {
                try
                {
                    var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                    var ex = exceptionHandlerFeature.Error;
                    if (ex is InputError)
                    {
                        var contentType = context.Response.ContentType;

                        context.Response.Clear();
                        context.Features.Set<IExceptionHandlerFeature>(exceptionHandlerFeature);
                        context.Features.Set<IExceptionHandlerPathFeature>(exceptionHandlerFeature);
                        context.Response.StatusCode = 500;
                        context.Response.OnStarting(ClearCacheHeaders, context.Response);
                    }
                        
                }
                catch (Exception)
                {

                    throw;
                }
            };

            var exceptionHandlerOptions = new ExceptionHandlerOptions()
            {
                 ExceptionHandler = handle

            };

            return app;

        }

        private static Task ClearCacheHeaders(object state)
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
