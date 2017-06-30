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
    public static class VueExtensions
    {
        public static string VueValidateRoleFor<TModel, TProperty>(this IHtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression)
        {
            ExpressionHelper.GetExpressionText(expression);
            var modelExplorer = ExpressionMetadataProvider.FromLambdaExpression(expression, helper.ViewData, helper.MetadataProvider);
            if (modelExplorer == null)
            {
                var expressionName = ExpressionHelper.GetExpressionText(expression);
                throw new InvalidOperationException(expressionName);
            }

            if (expression.Body.NodeType != ExpressionType.MemberAccess)
                return null;
            var propInfo = (expression.Body as MemberExpression).Member as PropertyInfo;
            var attrs = propInfo.GetCustomAttributes();
            dynamic role = new object();
            foreach (var attr in attrs)
            {
                var attrType = attr.GetType();
                if (attrType != typeof(ValidationAttribute) && attrType.GetTypeInfo().IsAssignableFrom(typeof(ValidationAttribute)))
                    continue;

                if (attrType == typeof(RequiredAttribute))
                {
                    role.Required = true;
                    continue;
                }

                if (attrType == typeof(CompareAttribute))
                {
                    continue;
                }


                if (attrType == typeof(DataTypeAttribute))
                {
                    continue;
                }

                if (attrType == typeof(MaxLengthAttribute))
                {
                    continue;
                }

                if (attrType == typeof(MinLengthAttribute))
                {
                    continue;
                }

                if (attrType == typeof(RangeAttribute))
                {
                    continue;
                }

                if (attrType == typeof(RegularExpressionAttribute))
                {
                    continue;
                }

                if (attrType == typeof(StringLengthAttribute))
                {
                    continue;
                }

                //if (attrType == typeof(MembershipPasswordAttribute))
                //{
                //    continue;
                //}

            }


            return JsonUtil.Serialize(role);



            var modelMetadata = (expression, helper.ViewData);

        }
    }
}
