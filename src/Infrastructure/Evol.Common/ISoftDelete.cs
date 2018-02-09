using System;

namespace Evol.Common
{
    public interface ISoftDelete
    {
        bool IsDeleted { get; set; }

        DateTime? DeleteTime{ get; set; }
    }
}
