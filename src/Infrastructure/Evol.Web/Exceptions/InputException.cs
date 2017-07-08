using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evol.Web.Exceptions
{
    /// <summary>
    /// 输入异常
    /// </summary>
    public class InputException : Exception
    {
        public Dictionary<string, string> ErrorState { get; set; }
        public InputException(Dictionary<string, string> errorState, string message) : base(message)
        {
            ErrorState = errorState;
        }
    }
}
