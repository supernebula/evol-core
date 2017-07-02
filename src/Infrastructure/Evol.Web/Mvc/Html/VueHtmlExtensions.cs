using Evol.Util.Serialization;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq.Expressions;

namespace Evol.Web.Mvc.Html
{
    public static class VueHtmlExtensions
    {
        public static string VueValidateRoleFor<TModel>(this IHtmlHelper helper) where TModel : class
        {
            var role = VueValidatorRuleModelHelper.GetModelRole<TModel>();
            return JsonUtil.Serialize(role);

        }

        public static string VueValidateRoleFor<TModel, TProperty>(this IHtmlHelper helper, Expression<Func<TModel, TProperty>> expression)
        {
            var role = VueValidatorRulePropertyHelper.GetPropRole(expression);
            return JsonUtil.Serialize(role);
        }


        
    }
}
