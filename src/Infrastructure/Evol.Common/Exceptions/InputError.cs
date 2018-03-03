using System;
using System.Collections.Generic;

namespace Evol.Common.Exceptions
{
    /// <summary>
    /// 输入异常
    /// </summary>
    public class InputError : Error
    {
        public Dictionary<string, string> ModelError { get; private set; }

        public Exception Exception { get; private set; }

        public InputError(string message) : base(message)
        {
        }

        public InputError(Dictionary<string, string> modelErrorDic, string message, Exception innerEx = null) : base(message, innerEx)
        {
            ModelError = modelErrorDic;
        }
    }
}
