using Microsoft.AspNetCore.Builder;
using System;

namespace Evol.Web.Middlewares
{
    public static class VisitAuditMiddlewareExtension
    {

        public static IApplicationBuilder UserVisitAudit(this IApplicationBuilder app)
        {
            if (app == null)
                throw new ArgumentNullException("app");
            app.UseMiddleware<VisitAuditMiddleware>();
            return app;
        }
    }
}
