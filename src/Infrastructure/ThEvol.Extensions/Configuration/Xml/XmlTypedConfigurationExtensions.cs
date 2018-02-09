using System;

namespace Evol.Extensions.Configuration.Xml
{
    public static class XmlTypedConfigurationExtensions
    {
        public static ITypedConfigurationBuilder AddXmlFile<T>(this ITypedConfigurationBuilder builder, string path, bool optional, bool reloadOnChange)
        {
            if (builder == null)
            {
                throw new ArgumentNullException("builder");
            }
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException(nameof(path));
            }
            XmlTypedConfigurationSource jsonConfigurationSource = new XmlTypedConfigurationSource(typeof(T))
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
