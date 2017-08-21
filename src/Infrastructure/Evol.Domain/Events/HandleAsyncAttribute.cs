using System;
using System.Collections.Generic;
using System.Text;

namespace Evol.Domain.Events
{
    /// <summary>
    ///  Non-transactional event handle
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class HandleAsyncAttribute : Attribute
    {

    }
}
