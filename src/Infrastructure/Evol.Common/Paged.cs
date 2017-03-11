using System.Collections.Generic;

namespace Evol.Common
{
    public class Paged<T> : List<T>, IPaged<T>
    {
        public int PageTotal { set; get; }

        public int RecordTotal { set; get; }

        public int Index { set; get; }

        public int Size { set; get; }
    }
}
