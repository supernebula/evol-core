using System.Collections.Generic;

namespace Evol.Common
{

    public class PagedList<T> : List<T>, IPaged<T>
    {

        public PagedList()
        {
        }
        public PagedList(IEnumerable<T> items, int total, int pageIndex, int pageSize)
        {
            this.AddRange(items);
            RecordTotal = total;
            Index = pageIndex;
            Size = pageSize;
            PageTotal = total / pageSize;
            if (total % pageSize > 0)
                PageTotal++;
        }
        public int PageTotal { set; get; }

        public int RecordTotal { set; get; }

        public int Index { set; get; }

        public int Size { set; get; }
    }
}
