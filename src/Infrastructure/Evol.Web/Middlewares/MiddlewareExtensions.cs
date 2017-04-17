using Microsoft.AspNetCore.Builder;
using System;

namespace Evol.Web.Middlewares
{
    public static class VisitAuditMiddlewareExtension
    {

        public static IApplicationBuilder UseVisitAudit(this IApplicationBuilder app)
        {
            if (app == null)
                throw new ArgumentNullException("app");
            app.UseMiddleware<VisitAuditMiddleware>();
            return app;
        }

        public static IApplicationBuilder UseUnhandledException(this IApplicationBuilder app)
        {
            if (app == null)
                throw new ArgumentNullException("app");
            app.UseMiddleware<UnhandledExceptionMiddleware>();
            return app;
        }

        public static IApplicationBuilder UserAppConfigRequestServicesMiddleware(this IApplicationBuilder app)
        {
            if (app == null)
                throw new ArgumentNullException("app");
            app.UseMiddleware<AppConfigRequestServicesMiddleware>();
            return app;
        }
    }
}
