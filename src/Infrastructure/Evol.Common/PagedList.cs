using System.Collections.Generic;
using System;
using System.Collections;

namespace Evol.Common
{

    public class PagedList<T> : IPaged<T> //List<T>, IPaged<T>
    {

        public PagedList()
        {
        }
        public PagedList(IEnumerable<T> items, int total, int pageIndex, int pageSize)
        {
            Items = items ?? throw new ArgumentNullException(nameof(items));
            RecordTotal = total;
            PageIndex = pageIndex;
            PageSize = pageSize;
            PageTotal = total / pageSize;
            if (total % pageSize > 0)
                PageTotal++;
        }

        public IEnumerable<T> Items { get; private set; }

        IEnumerable IPaged.Items { get {  return Items; }  }

        public int PageTotal { private set;  get; }

        public int RecordTotal { private set; get; }

        public int PageIndex { private set; get; }

        public int PageSize { private set; get; }

    }
}
