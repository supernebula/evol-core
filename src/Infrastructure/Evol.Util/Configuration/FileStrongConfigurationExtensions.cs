using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using System;

namespace Evol.Util.Configuration
{
    public static class FileStrongConfigurationExtensions
    {

        private static string FileProviderKey = "FileProvider";

        private static string FileLoadExceptionHandlerKey = "FileLoadExceptionHandler";

        public static IStrongConfigurationBuilder SetBasePath(this IStrongConfigurationBuilder builder, string basePath)
        {
            throw new NotImplementedException();
        }

        public static IFileProvider GetFileProvider(this IStrongConfigurationBuilder builder)
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

        public static Action<FileLoadExceptionContext> GetFileLoadExceptionHandler(this IStrongConfigurationBuilder builder)
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
