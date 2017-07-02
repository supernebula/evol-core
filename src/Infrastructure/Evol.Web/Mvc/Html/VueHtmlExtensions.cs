using Evol.Util.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Resources;
using System.Threading.Tasks;

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
