using System;
using System.Collections.Generic;
using System.Text;

namespace Evol.Common.Logging
{
    //
    // 摘要:
    //     Represents a type that can create instances of Evol.Common.Logging.ILogger.
    public interface ILoggerProvider : IDisposable
    {
        //
        // 摘要:
        //     Creates a new Evol.Common.Logging.ILogger instance.
        //
        // 参数:
        //   categoryName:
        //     The category name for messages produced by the logger.
        ILogger CreateLogger(string categoryName);
    }
}
