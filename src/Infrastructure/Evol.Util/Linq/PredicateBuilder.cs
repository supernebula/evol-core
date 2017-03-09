using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Nebula.Util.Linq
{
    public class PredicateBuilder
    {
        public Expression<Func<T, bool>> And<T>(Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            throw new NotImplementedException();
        }
    }
}
