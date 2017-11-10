using Evol.Configuration;
using Evol.TMovie.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;

namespace Evol.TMovie.Manage.Filters
{
    /// <summary>
    /// 有效的授权验证特性。
    /// 自带验证属性<see cref="Microsoft.AspNetCore.Authorization.AuthorizeAttribute"/>粒度粗，无法满足对权限点、资源点的控制
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class AuthorizeFilterAttribute : ActionFilterAttribute
    {
        private string _permissionCode;

        /// <summary>
        /// 权限点编码
        /// </summary>
        /// <param name="permissionCode"></param>
        public AuthorizeFilterAttribute(string permissionCode)
        {
            _permissionCode = permissionCode;
        }
        //
        public override void OnActionExecuted(ActionExecutedContext context)
        {

            if (context.Filters.Any(item => item is IAllowAnonymousFilter))
                return;

            var employeeIdStr = context.HttpContext.User.Claims.First(e => e.Type == "id").Value;
            var employeeId = Guid.Parse(employeeIdStr);
            var sessionId = context.HttpContext.Session.Id;
            var employeeAuthService = AppConfig.Current.IoCManager.GetService<IEmployeePermissionService>();
            if (employeeAuthService.ValidatePermissionAsync(employeeId, _permissionCode, sessionId).GetAwaiter().GetResult())
            {
                base.OnActionExecuted(context);
            }
            else
            {
                context.Result = new UnauthorizedResult();
            }
            
        }
        //
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
        }
    }
}
