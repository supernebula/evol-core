using Microsoft.AspNetCore.Builder;
using System;

namespace Evol.Web.Middlewares
{
    public static class UnhandledExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseUnhandledException(this IApplicationBuilder app)
        {
            if (app == null)
                throw new ArgumentNullException("app");
            app.UseMiddleware<UnhandledExceptionMiddleware>();
            return app;
        }
    }
}
