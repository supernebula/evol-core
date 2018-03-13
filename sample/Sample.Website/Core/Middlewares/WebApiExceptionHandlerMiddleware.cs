using Evol.Common.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Website.Core.Middlewares
{
    /// <summary>
    /// WebAPI异常处理中间件
    /// </summary>
    public class WebApiExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly ExceptionHandlerOptions _options;

        private readonly Func<object, Task> _clearCacheHeadersDelegate;

        private readonly ILogger _logger;

        private readonly DiagnosticSource _diagnosticSource;

        public WebApiExceptionHandlerMiddleware(RequestDelegate next, ILoggerFactory loggerFactory, IOptions<ExceptionHandlerOptions> options, DiagnosticSource diagnosticSource)
        {
            _next = next;
            this._options = options.Value;
            _logger = loggerFactory.CreateLogger<WebApiExceptionHandlerMiddleware>();
            _clearCacheHeadersDelegate = ClearCacheHeaders;
            if ((object)this._options.ExceptionHandler == null)
            {
                this._options.ExceptionHandler = this._next;
            }
            this._diagnosticSource = diagnosticSource;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(new EventId(1, "UnhandledException"), ex, "An unhandled exception while request");
                // We can't do anything if the response has already started, just abort.
                if (context.Response.HasStarted)
                {
                    _logger.LogError(new EventId(2, "ResponseStartedErrorHandler"), ex, "ResponseStartedErrorHandler");
                    throw;
                }

                PathString originalPath = context.Request.Path;
                if (_options.ExceptionHandlingPath.HasValue)
                {
                    context.Request.Path = _options.ExceptionHandlingPath;
                }
                try
                {
                    context.Response.Clear();
                    var exceptionHandlerFeature = new ExceptionHandlerFeature()
                    {
                        Error = ex,
                        Path = originalPath.Value,
                    };
                    context.Features.Set<IExceptionHandlerFeature>(exceptionHandlerFeature);
                    context.Features.Set<IExceptionHandlerPathFeature>(exceptionHandlerFeature);
                    context.Response.StatusCode = 500;
                    context.Response.OnStarting(_clearCacheHeadersDelegate, context.Response);

                    await _options.ExceptionHandler(context);

                    if (_diagnosticSource.IsEnabled("Microsoft.AspNetCore.Diagnostics.HandledException"))
                    {
                        _diagnosticSource.Write("Microsoft.AspNetCore.Diagnostics.HandledException", new { httpContext = context, exception = ex });
                    }

                    // TODO: Optional re-throw? We'll re-throw the original exception by default if the error handler throws.
                    return;
                }
                catch (Exception ex2)
                {
                    // Suppress secondary exceptions, re-throw the original.
                    _logger.LogError(new EventId(3, "ErrorHandlerException"), ex, "ErrorHandlerException");
                }
                finally
                {
                    context.Request.Path = originalPath;
                }
                throw; // Re-throw the original if we couldn't handle it
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
