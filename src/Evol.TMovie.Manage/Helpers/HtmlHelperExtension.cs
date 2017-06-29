using Evol.Domain;
using Evol.TMovie.Domain.Services;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Evol.TMovie.Manage.Helpers
{
    public static class HtmlHelperExtension
    {
        /// <summary>
        /// 验证当前登录用户是否有此权限
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="permissionCode"></param>
        /// <returns></returns>
        public static async Task<bool> HasEmployeePermissionAsync(this HtmlHelper htmlHelper, string permissionCode)
        {
            var userIdStr = htmlHelper.ViewContext.HttpContext.User.Claims.First(e => e.Type == "id").Value;
            var userId = Guid.Parse(userIdStr);
            var sessionId = htmlHelper.ViewContext.HttpContext.Session.Id;
            var service = AppConfig.Current.IoCManager.GetService<IEmployeePermissionService>();
            var flag =await service.ValidatePermissionAsync(userId, permissionCode, sessionId);
            return flag;
        }
    }
}
