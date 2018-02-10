using Evol.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Evol.Web.Middlewares
{
    [Obsolete("未完成...")]
    public class AppConfigRequestServicesMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public AppConfigRequestServicesMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<AppConfigRequestServicesMiddleware>();
            _next = next;
        }

        [Obsolete("未实现...")]
        public async Task Invoke(HttpContext context)
        {
            throw new NotImplementedException();
            //AppConfig.ConfigPerRequestServiceProvider(() => context.RequestServices);
            await _next.Invoke(context);
        }
    }
}
