using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Reflection;

namespace Evol.Web.Mvc.Html
{
    public static class VueValidatorRulePropertyHelper
    {
        public static Dictionary<object, object> GetPropRole<TModel, TProperty>(Expression<Func<TModel, TProperty>> memberExpression)
        {
            if (memberExpression.Body.NodeType != ExpressionType.MemberAccess)
                throw new ArgumentException(nameof(MemberExpression) + "不是ExpressionType.MemberAccess类型");

            //ExpressionHelper.GetExpressionText(expression);
            //var modelExplorer = ExpressionMetadataProvider.FromLambdaExpression(expression, helper.ViewData, helper.MetadataProvider);

            var propInfo = (memberExpression.Body as MemberExpression).Member as PropertyInfo;
            if (propInfo == null)
                return null;
            return GetPropRoleByAttribute(propInfo.GetCustomAttributes());
        }


        public static Dictionary<object, object> GetPropRole(PropertyDescriptor propDescriptor)
        {
            if (propDescriptor == null)
                throw new ArgumentNullException(nameof(propDescriptor));

            var roleDic = new Dictionary<object, object>();
            var attrs = propDescriptor.Attributes;
            var attrList = new List<Attribute>();
            foreach (Attribute item in attrs)
            {
                attrList.Add(item);
            }
            return GetPropRoleByAttribute(attrList);
        }

        private static Dictionary<object, object> GetPropRoleByAttribute(IEnumerable<Attribute> propAttributes)
        {
            if (propAttributes == null)
                throw new ArgumentNullException(nameof(propAttributes));

            var roleDic = new Dictionary<object, object>();
            var attrs = propAttributes;

            foreach (var attr in attrs)
            {
                var attrType = attr.GetType();
                if (attrType != typeof(ValidationAttribute) && attrType.GetTypeInfo().IsAssignableFrom(typeof(ValidationAttribute)))
                    continue;

                if (attrType == typeof(RequiredAttribute))
                {
                    roleDic.Add("required", true);
                    continue;
                }

                if (attrType == typeof(RegularExpressionAttribute))
                {
                    roleDic.Add("pattern", ((RegularExpressionAttribute)attr).Pattern);
                    continue;
                }



                if (attrType == typeof(MaxLengthAttribute))
                {
                    roleDic.Add("maxlength", ((MaxLengthAttribute)attr).Length);
                    continue;
                }

                if (attrType == typeof(MinLengthAttribute))
                {
                    roleDic.Add("minlength", ((MinLengthAttribute)attr).Length);
                    continue;
                }

                if (attrType == typeof(StringLengthAttribute))
                {
                    roleDic.Add("maxlength", ((StringLengthAttribute)attr).MaximumLength);
                    roleDic.Add("minlength", ((StringLengthAttribute)attr).MinimumLength);
                    continue;
                }

                if (attrType == typeof(RangeAttribute))
                {
                    var rangeAttr = (RangeAttribute)attr;
                    if ((double)rangeAttr.Maximum > 0)
                        roleDic.Add("max", ((RangeAttribute)attr).Maximum);
                    if ((double)rangeAttr.Minimum > 0)
                        roleDic.Add("min", ((RangeAttribute)attr).Minimum);
                    continue;
                }

                #region 更多验证特性
                //if (attrType == typeof(CompareAttribute))
                //{
                //    roleDic.Add("required", true);
                //    continue;
                //}

                //if (attrType == typeof(DataTypeAttribute))
                //{
                //    roleDic.Add("datatype", ((DataTypeAttribute)attr).DataType);
                //    continue;
                //}

                //if (attrType == typeof(MembershipPasswordAttribute))
                //{
                //    continue;
                //}
                #endregion
            }

            return roleDic;
        }
    }
}
