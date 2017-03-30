using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using System;

namespace Evol.Util.Configuration
{
    public static class FileTypedConfigurationExtensions
    {

        private static string FileProviderKey = "FileProvider";

        private static string FileLoadExceptionHandlerKey = "FileLoadExceptionHandler";

        public static ITypedConfigurationBuilder SetBasePath(this ITypedConfigurationBuilder builder, string basePath)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            if (basePath == null)
            {
                throw new ArgumentNullException(nameof(basePath));
            }

            return builder.SetFileProvider(new PhysicalFileProvider(basePath));
        }

        public static ITypedConfigurationBuilder SetFileProvider(this ITypedConfigurationBuilder builder, IFileProvider fileProvider)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.Properties[FileProviderKey] = fileProvider ?? throw new ArgumentNullException(nameof(fileProvider));
            return builder;
        }

        public static IFileProvider GetFileProvider(this ITypedConfigurationBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException("builder");
            }
            object obj;

            if (builder.Properties.TryGetValue(FileProviderKey, out obj))
            {
                return builder.Properties[FileProviderKey] as IFileProvider;
            }
            return new PhysicalFileProvider(AppContext.BaseDirectory ?? string.Empty);
        }

        public static Action<FileLoadExceptionContext> GetFileLoadExceptionHandler(this ITypedConfigurationBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException("builder");
            }
            object obj;
            if (builder.Properties.TryGetValue(FileLoadExceptionHandlerKey, out obj))
            {
                return builder.Properties[FileLoadExceptionHandlerKey] as Action<FileLoadExceptionContext>;
            }
            return null;
        }
    }
}
