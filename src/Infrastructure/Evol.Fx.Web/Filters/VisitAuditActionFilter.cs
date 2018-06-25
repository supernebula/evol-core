using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;

namespace Evol.Fx.Web.Filters
{
    public class VisitAuditActionFilter : ActionFilterAttribute, IActionFilter
    {
        //
        // 摘要:
        //     Called after the action method executes.
        //
        // 参数:
        //   filterContext:
        //     The filter context.
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //var path = filterContext.RequestContext.
        }
    }
}
