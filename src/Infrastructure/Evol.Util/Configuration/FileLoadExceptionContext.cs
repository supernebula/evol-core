using System;
using System.Collections.Generic;
using System.Text;

namespace Evol.Util.Configuration
{
    public class FileLoadExceptionContext
    {
        /// <summary>
        /// The <see cref="FileTypedConfigurationProvider"/> that caused the exception.
        /// </summary>
        public FileTypedConfigurationProvider Provider { get; set; }

        /// <summary>
        /// The exception that occured in Load.
        /// </summary>
        public Exception Exception { get; set; }

        /// <summary>
        /// If true, the exception will not be rethrown.
        /// </summary>
        public bool Ignore { get; set; }
    }
}
