using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace TestLINQ
{
    public static class DynamicQuery
    {
        #region Expression Extension
        #region 替换参数类型
        /// <summary>
        /// happyhippy Extension : 将Lambda的第一个泛型参数TSource类型替换为TResult类型
        /// </summary>
        /// <typeparam name="TSource">源类型</typeparam>
        /// <typeparam name="TResult">目标类型</typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static Expression<Func<TResult, bool>> Replace<TSource, TResult>(
            this Expression<Func<TSource, bool>> predicate)
        {
            ParameterConverter pc = new ParameterConverter(predicate);
            return (Expression<Func<TResult, bool>>)pc.Replace(typeof(TResult));
        }

        /// <summary>
        /// happyhippy Extension : 将Lambda的第一个泛型参数TSource类型替换为targetType类型
        /// </summary>
        /// <typeparam name="TSource">源类型</typeparam>
        /// <param name="predicate"></param>
        /// <param name="targetType">目标类型</param>
        /// <returns></returns>
        public static LambdaExpression Replace<TSource>(
            this Expression<Func<TSource, bool>> predicate, Type targetType)
        {
            ParameterConverter pc = new ParameterConverter(predicate);
            return (LambdaExpression)pc.Replace(targetType);
        }
        #endregion

        #region 对Lambda表达式进行拼接
        /// <summary>
        /// happyhippy Extension : 将两个Lambda表达式进行AndAlso连接
        /// </summary>
        /// <typeparam name="TLeft">左表达式的泛型参数</typeparam>
        /// <typeparam name="TRight">右表达式的泛型参数</typeparam>
        /// <param name="left">左表达式</param>
        /// <param name="right">右表达式</param>
        /// <returns></returns>
        public static Expression<Func<TLeft, bool>> AndAlso<TLeft, TRight>(this Expression<Func<TLeft, bool>> left,
            Expression<Func<TRight, bool>> right)
        {
            return Append<TLeft, TRight>(left, right, Expression.AndAlso);
        }

        /// <summary>
        /// happyhippy Extension : 将两个Lambda表达式进行OrElse连接
        /// </summary>
        /// <typeparam name="TLeft">左表达式的泛型参数</typeparam>
        /// <typeparam name="TRight">右表达式的泛型参数</typeparam>
        /// <param name="left">左表达式</param>
        /// <param name="right">右表达式</param>
        /// <returns></returns>
        public static Expression<Func<TLeft, bool>> OrElse<TLeft, TRight>(this Expression<Func<TLeft, bool>> left,
            Expression<Func<TRight, bool>> right)
        {
            return Append<TLeft, TRight>(left, right, Expression.OrElse);
        }

        /// <summary>
        /// happyhippy Extension : 将两个(具有相同泛型参数)Lambda表达式进行AndAlso连接
        /// </summary>
        /// <typeparam name="T">表达式的泛型参数</typeparam>
        /// <param name="left">左表达式</param>
        /// <param name="right">右表达式</param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> AndAlso<T>(this Expression<Func<T, bool>> left,
            Expression<Func<T, bool>> right)
        {
            return Append<T, T>(left, right, Expression.AndAlso);
        }

        /// <summary>
        /// happyhippy Extension : 将两个(具有相同泛型参数)Lambda表达式进行OrElse连接
        /// </summary>
        /// <typeparam name="T">表达式的泛型参数</typeparam>
        /// <param name="left">左表达式</param>
        /// <param name="right">右表达式</param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> OrElse<T>(this Expression<Func<T, bool>> left,
            Expression<Func<T, bool>> right)
        {
            return Append<T, T>(left, right, Expression.OrElse);
        }

        private static Expression<Func<TLeft, bool>> Append<TLeft, TRight>(
            this Expression<Func<TLeft, bool>> left, Expression<Func<TRight, bool>> right,
            Func<Expression, Expression, Expression> appendAction)
        {
            if (left == null)
                return (Expression<Func<TLeft, bool>>)(new ParameterConverter(right).Replace(typeof(TLeft)));
            if (right == null)
                return (Expression<Func<TLeft, bool>>)(new ParameterConverter(left).Replace(typeof(TLeft)));

            ParameterExpression parameter = (ParameterExpression)left.Parameters[0];
            LambdaExpression rightExpression = new ParameterConverter(right, parameter).Replace(typeof(TLeft));

            Expression newBody = appendAction(left.Body, rightExpression.Body);
            return Expression.Lambda<Func<TLeft, bool>>(newBody, left.Parameters);
        }
        #endregion

        #region 批量删除/批量更新Expression扩展
        public static Expression Visit<T>(
            this Expression exp,
            Func<T, Expression> visitor) where T : Expression
        {
            return ExpressionVisitor<T>.Visit(exp, visitor);
        }

        public static TExp Visit<T, TExp>(
            this TExp exp,
            Func<T, Expression> visitor)
            where T : Expression
            where TExp : Expression
        {
            return (TExp)ExpressionVisitor<T>.Visit(exp, visitor);
        }

        public static Expression<TDelegate> Visit<T, TDelegate>(
            this Expression<TDelegate> exp,
            Func<T, Expression> visitor) where T : Expression
        {
            return ExpressionVisitor<T>.Visit<TDelegate>(exp, visitor);
        }

        public static IQueryable<TSource> Visit<T, TSource>(
            this IQueryable<TSource> source,
            Func<T, Expression> visitor) where T : Expression
        {
            return source.Provider.CreateQuery<TSource>(ExpressionVisitor<T>.Visit(source.Expression, visitor));
        }
        #endregion
        #endregion

        #region DynamicQuery
        /// <summary>
        /// happyhippy Extension:动态查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IQueryable DynamicWhere<T>(this IQueryable query, Expression<Func<T, bool>> predicate)
        {
            if (predicate == null)
                return query;

            return query.Provider.CreateQuery(
                Expression.Call(
                    typeof(Queryable), "Where",
                    new Type[] { query.ElementType },
                    query.Expression, predicate.Replace(query.ElementType)));
        }
        #endregion
    }
}
