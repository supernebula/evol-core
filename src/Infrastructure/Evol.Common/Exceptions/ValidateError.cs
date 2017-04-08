using System;

namespace Evol.Common.Exceptions
{
    /// <summary>
    /// 输入错误
    /// </summary>
    public class ValidateError : Error
    {
        public ValidateError(string message) : base(message)
        { }


        public ValidateError(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
