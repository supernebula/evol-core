using System;
using System.Collections.Generic;
using System.Text;

namespace Evol.Util.Configuration
{
    public static class JsonStrongConfigurationExtensions
    {
        public static IStrongConfigurationBuilder AddJsonFile<T>(this IStrongConfigurationBuilder builder, string path, bool optional, bool reloadOnChange)
        {
            if (builder == null)
            {
                throw new ArgumentNullException("builder");
            }
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException(nameof(path));
            }
            JsonConfigurationSource jsonConfigurationSource = new JsonConfigurationSource
            {
                FileProvider = provider,
                Path = path,
                Optional = optional,
                ReloadOnChange = reloadOnChange
            };
            jsonConfigurationSource.ResolveFileProvider();
            builder.Add(jsonConfigurationSource);
            return builder;
        }
    }
}
