using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace Evol.Util.Configuration
{
    public abstract class FileTypedConfigurationProvider : TypedConfigurationProvider
    {
        public FileTypedConfigurationSource Source { get; }

        public override Type StrongType
        {
            get
            {
                return Source.StrongType;
            }
        }

        /// <summary>
        /// Initializes a new instance with the specified source.
        /// </summary>
        /// <param name="source">The source settings.</param>
        public FileTypedConfigurationProvider(FileTypedConfigurationSource source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            Source = source;

            if (Source.ReloadOnChange && Source.FileProvider != null)
            {
                ChangeToken.OnChange(
                    () => Source.FileProvider.Watch(Source.Path),
                    () => {
                        Thread.Sleep(Source.ReloadDelay);
                        Load(reload: true);
                    });
            }
        }

        /// <summary>
        /// The source settings for this provider.
        /// </summary>
        

        private void Load(bool reload)
        {
            var file = Source.FileProvider?.GetFileInfo(Source.Path);
            if (file == null || !file.Exists)
            {
                if (Source.Optional || reload) // Always optional on reload
                {
                    Data = null;
                }
                else
                {
                    var error = new StringBuilder($"The configuration file '{Source.Path}' was not found and is not optional.");
                    if (!string.IsNullOrEmpty(file?.PhysicalPath))
                    {
                        error.Append($" The physical path is '{file.PhysicalPath}'.");
                    }
                    throw new FileNotFoundException(error.ToString());
                }
            }
            else
            {
                // Always create new Data on reload to drop old keys
                if (reload)
                {
                    Data = null;
                }
                using (var stream = file.CreateReadStream())
                {
                    try
                    {
                        Load(stream);
                    }
                    catch (Exception e)
                    {
                        bool ignoreException = false;
                        if (Source.OnLoadException != null)
                        {
                            var exceptionContext = new FileLoadExceptionContext
                            {
                                Provider = this,
                                Exception = e
                            };
                            Source.OnLoadException.Invoke(exceptionContext);
                            ignoreException = exceptionContext.Ignore;
                        }
                        if (!ignoreException)
                        {
                            throw e;
                        }
                    }
                }
            }
            // REVIEW: Should we raise this in the base as well / instead?
            OnReload();
        }

        /// <summary>
        /// Loads the contents of the file at <see cref="Path"/>.
        /// </summary>
        /// <exception cref="FileNotFoundException">If Optional is <c>false</c> on the source and a
        /// file does not exist at specified Path.</exception>
        public override void Load()
        {
            Load(reload: false);
        }

        /// <summary>
        /// Loads this provider's data from a stream.
        /// </summary>
        /// <param name="stream">The stream to read.</param>
        public abstract void Load(Stream stream);
    }
}
