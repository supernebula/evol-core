using Evol.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Evol.Web.Middlewares
{
    public class AppConfigRequestServicesMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public AppConfigRequestServicesMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<AppConfigRequestServicesMiddleware>();
            _next = next;
        }


        public async Task Invoke(HttpContext context)
        {
            AppConfig.ConfigPerRequestServiceProvider(() => context.RequestServices);
            await _next.Invoke(context);
        }
    }
}
