using System;

namespace Evol.Common.Exceptions
{
    /// <summary>
    /// 错误基类
    /// </summary>
    public abstract class Error : Exception
    {
        public Error(string message) : base(message)
        { }


        public Error(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
