using System;
using System.Linq.Expressions;

namespace Evol.Util.Expressions
{
    /// <summary>
    /// IQueryable<T> 查询条件构建器, 目前只实现 &&、||
    /// 使用方法, 如下：
    /// var predicate = LambdaPredicateBuilder.True<T>().And(t.Property1 == constant1).And(t.Property2 > constant2, constant2).Or(t.Property3 > constant3, constant3);
    /// var result = IQueryable<T>.Where(predicate);
    /// 将验证变量queryConstant的有效性
    /// </summary>
    public static class LambdaValidPredicateBuilder
    {

        private class DefaultExpression<T>
        {
            public static Expression<Func<T, bool>> lambdaTrue = f => true;
            public static Expression<Func<T, bool>> lambdaFalse = f => false;
        }
        public static Expression<Func<T, bool>> True<T>() { return DefaultExpression<T>.lambdaTrue; }
        public static Expression<Func<T, bool>> False<T>() { return DefaultExpression<T>.lambdaTrue; }

        /// <summary>
        /// leftExpression && rightExpression, 如果rightExpression中的常量无效，则不拼接，只返回leftExpression
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> left, Expression<Func<T, bool>> right)
        {
            return Merge(left, right, Expression.AndAlso);
        }

        /// <summary>
        /// leftExpression || rightExpression, 如果rightExpression中的常量无效，则不拼接，只返回leftExpression
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> left, Expression<Func<T, bool>> right)
        {
            return Merge(left, right, Expression.OrElse);
        }

        /// <summary>
        /// leftExpression 表达式操作符 rightExpression, 如果rightExpression中的常量无效，则不拼接，只返回leftExpression
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="exprOperate"></param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> Merge<T>(Expression<Func<T, bool>> left, Expression<Func<T, bool>> right, Func<Expression, Expression, Expression> exprOperate)
        {
            if (!ExpressionConstantIsValid(right))
                return left;

            var condidateExpr = Expression.Parameter(typeof(T), "candidate");
            var parameterReplacer = new ExpressionParameterReplacer<T>(condidateExpr);
            var leftBody = parameterReplacer.Repalce(left.Body);
            var rightBody = parameterReplacer.Repalce(right.Body);
            var binaryBody = exprOperate(leftBody, rightBody);

            var lambda = Expression.Lambda<Func<T, bool>>(binaryBody, condidateExpr);
            return lambda;
        }

        private static bool ExpressionConstantIsValid<T>(Expression<Func<T, bool>> expr)
        {
            var constantValidtor = new ExpressionConstantValidator(ConstantNotNull);
            return constantValidtor.Validate(expr);
        }


        private static bool ConstantNotNull(object value)
        {
            if (value == null)
                return false;
            if ((value is string) && string.IsNullOrWhiteSpace(value.ToString()))
                return false;
            if (value is Array && ((Array)value).Length == 0)
                return false;
            return true;
        }
    }
}
