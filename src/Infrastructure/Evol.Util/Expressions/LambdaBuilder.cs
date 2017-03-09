using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Evol.Util.Expressions
{
    public static class LambdaBuilderExtension
    {
        public static Expression<Func<T, bool>> Lambda<T>(this T model)
        {
            return null;
        }
        public static Expression<Func<T, bool>> AppendIf<T>(this Expression<Func<T, bool>> left, bool assert, Expression<Func<T, bool>> predicate)
        {
            if (!assert)
                return left;
            if (left == null)
                return predicate;
            return left.And(predicate);
        }
    }
}
