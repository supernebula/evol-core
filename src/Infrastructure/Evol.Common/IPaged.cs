using System.Collections;
using System.Collections.Generic;
using System;

namespace Evol.Common
{
    public interface IPaged<T> : IPaged //, IEnumerable<T>
    {
        new IEnumerable<T> Items { get; }
    }


    public interface IPaged
    {
        IEnumerable Items { get; }

        int PageTotal { get; }

        int RecordTotal { get; }

        int Index { get; }

        int Size { get; }

    }
}
