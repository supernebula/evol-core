using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evol.Web.Middlewares
{
    public static class VisitAuditMiddlewareExtension
    {

        public static IApplicationBuilder UserVisitAudit(this IApplicationBuilder app)
        {
            if (app == null)
                throw new ArgumentNullException("app");

            //log and database
            throw new NotImplementedException();
        }
    }
}
