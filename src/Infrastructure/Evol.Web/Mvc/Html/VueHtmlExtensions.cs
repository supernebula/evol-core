using Evol.Util.Serialization;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq.Expressions;

namespace Evol.Web.Mvc.Html
{
    public static class VueHtmlExtensions
    {
        /// <summary>
        /// 获取模型的所有属性验证规则
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="helper"></param>
        /// <returns></returns>
        public static string VueValidateRoleFor<TModel>(this IHtmlHelper helper) where TModel : class
        {
            var role = VueValidatorRuleModelHelper.GetModelRole<TModel>();
            return JsonUtil.Serialize(role);

        }

        /// <summary>
        /// 获取模型的单个属性验证规则
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="helper"></param>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static string VueValidateRoleFor<TModel, TProperty>(this IHtmlHelper helper, Expression<Func<TModel, TProperty>> expression)
        {
            var role = VueValidatorRulePropertyHelper.GetPropRole(expression);
            return JsonUtil.Serialize(role);
        }


        
    }
}
