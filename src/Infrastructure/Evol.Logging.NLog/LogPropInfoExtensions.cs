using System;
using System.Linq.Expressions;
using Evol.Common.Logging;

namespace Evol.Logging.AdapteNLog
{
    public static class LogPropInfoExtensions
    {

        /// <summary>
        /// 属性日志追加
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TP"></typeparam>
        /// <param name="model"></param>
        /// <param name="expression"></param>
        /// <param name="propName"></param>
        /// <returns></returns>
        public static LogPropInfo<T> AddProp<T, TP>(this T model, Expression<Func<T, TP>> expression, string propName = null)
        {
            var value = Expression.Invoke(expression);
            var propInfo = new LogPropInfo<T>(model);
            propInfo.AddProp<T, TP>(expression, propName);
            return propInfo;
        }

        public static LogPropInfo<T> AddProp<T, TP>(this LogPropInfo<T> propInfo, Expression<Func<T, TP>> expression, string propName = null)
        {
            var value = Expression.Invoke(expression);

            if (!string.IsNullOrWhiteSpace(propName))
            {
                propInfo[propName] = value;
                return propInfo;
            }


            if (expression is MemberExpression)
            {
                var exp = expression as MemberExpression;
                propInfo[propName ?? exp.Member.Name] = value;
                return propInfo;
            }


            propInfo[$"unkown_{expression.Name}"] = value;
            return propInfo;
        }

    }



}

