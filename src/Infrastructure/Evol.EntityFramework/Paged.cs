using System;
using System.Collections.Generic;
using Evol.Common;

namespace Evol.EntityFramework.Repository
{
    public class Paged<T> : List<T>, IPaged<T>
    {
        public Paged(IEnumerable<T> items, int total, int pageIndex, int pageSize)
        {
            this.AddRange(items);
            RecordTotal = total;
            Index = pageIndex;
            Size = pageSize;
            PageTotal = total / pageSize;
            if (total%pageSize > 0)
                PageTotal++;
        }
        public int Index { get;}

        public int PageTotal { get; }

        public int RecordTotal { get; }

        public int Size { get; }
    }
}
