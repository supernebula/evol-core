using System;
using System.Linq;

namespace Evol.Common
{
    public static class IPagedExtensions
    {
        public static IPaged<TK> Convert<T,TK>(this IPaged<T> paged, Func<T, TK> convertor){
            var ks = paged.Items.ToList().Select(e => convertor.Invoke(e)).ToList();
            return new PagedList<TK>(ks, paged.RecordTotal, paged.PageIndex, paged.PageSize);
        }
    }
}
