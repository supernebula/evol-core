using Evol.Common.Exceptions;
using Evol.Util.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Sample.Website.Core
{
    /// <summary>
    /// ExceptionHandlerMiddleware异常处理中间件扩展
    /// </summary>
    public static class CustomExceptionHandlerExtensions
    {

        /// <summary>
        /// 添加自定义的异常处理器，用于ExceptionHandlerMiddleware异常处理中间件
        /// </summary>
        /// <param name="app"></param>
        /// <param name="errorHandlingPath"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseCanContinueExceptionHandler(this IApplicationBuilder app, string errorHandlingPath)
        {
            RequestDelegate handle = async (context) =>  {
                var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                var ex = exceptionHandlerFeature.Error;
                var code = HttpStatusCode.InternalServerError;

                string result = null;
                if (ex is InputError)
                {
                    code = HttpStatusCode.BadRequest;
                    var error = ex as InputError;
                    var apiResult = new ApiResult(error.ModelError)
                    {
                        Code = PlatfamCode.Fail,
                        Msg = "请求失败",
                        ErrCode = BusinessCode.BadRequest,
                        ErrMsg = error.Message
                    };
                    result = JsonUtil.Serialize(apiResult);
                }

                if (result == null)
                    return;

                context.Response.Clear();
                context.Response.StatusCode = (int)code;
                await context.Response.WriteAsync(result);
                context.Response.OnStarting(ClearCacheHeaders, context.Response);
            };

            return app.UseExceptionHandler(new ExceptionHandlerOptions
            {
                ExceptionHandlingPath = errorHandlingPath,
                ExceptionHandler = handle
            });

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
