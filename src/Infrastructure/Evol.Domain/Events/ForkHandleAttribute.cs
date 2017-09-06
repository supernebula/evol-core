using System;
using System.Collections.Generic;
using System.Text;

namespace Evol.Domain.Events
{
    /// <summary>
    ///  Non-transactional event handle。Processed in a new thread, but not waiting for results
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class ForkHandleAttribute : Attribute
    {

    }
}
