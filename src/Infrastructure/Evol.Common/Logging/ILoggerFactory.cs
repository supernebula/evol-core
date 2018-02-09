using System;
using System.Collections.Generic;
using System.Text;

namespace Evol.Common.Logging
{
    //
    // 摘要:
    //     Represents a type used to configure the logging system and create instances of
    //     Evol.Common.Logging.ILogger from the registered Evol.Common.Logging.ILoggerProviders.
    public interface ILoggerFactory : IDisposable
    {
        ////
        //// 摘要:
        ////     Adds an Evol.Common.Logging.ILoggerProvider to the logging system.
        ////
        //// 参数:
        ////   provider:
        ////     Evol.Common.Logging.ILoggerProvider.
        //void AddProvider(ILoggerProvider provider);

        //
        // 摘要:
        //     Creates a new Evol.Common.Logging.ILogger instance.
        //
        // 参数:
        //   categoryName:
        //     The category name for messages produced by the logger.
        //
        // 返回结果:
        //     The Evol.Common.Logging.ILogger.
        ILogger CreateLogger(string categoryName);


        ILogger CreateLogger<T>();
    }
}
