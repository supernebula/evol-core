using System;
using System.Collections.Generic;
using System.Text;

namespace Evol.Util.Configuration
{
    public static class JsonTypedConfigurationExtensions
    {
        public static ITypedConfigurationBuilder AddJsonFile<T>(this ITypedConfigurationBuilder builder, string path, bool optional, bool reloadOnChange)
        {
            if (builder == null)
            {
                throw new ArgumentNullException("builder");
            }
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException(nameof(path));
            }
            JsonTypedConfigurationSource jsonConfigurationSource = new JsonTypedConfigurationSource(typeof(T))
            {
                FileProvider = null,// provider,
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
