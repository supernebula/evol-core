using System.Collections;
using System.Collections.Generic;

namespace Evol.Common
{
    public interface IPaged<out T> : IPaged, IEnumerable<T>
    {
    }


    public interface IPaged
    {
        int PageTotal { get; }

        int RecordTotal { get; }

        int Index { get; }

        int Size { get; }

    }
}
