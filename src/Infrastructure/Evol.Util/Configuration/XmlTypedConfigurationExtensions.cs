using System;
using System.Collections.Generic;
using System.Text;

namespace Evol.Util.Configuration
{
    public static class XmlTypedConfigurationExtensions
    {
        public static ITypedConfigurationBuilder AddXmlFile<T>(this ITypedConfigurationBuilder builder, string path, bool optional, bool reloadOnChange)
        {
            throw new NotImplementedException();
        }
    }
}
