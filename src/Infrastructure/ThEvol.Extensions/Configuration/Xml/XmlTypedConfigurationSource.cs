using System;

namespace Evol.Extensions.Configuration.Xml
{

    public class XmlTypedConfigurationSource : FileTypedConfigurationSource
    {
        public XmlTypedConfigurationSource(Type strongType) : base(strongType)
        {
        }

        public override ITypedConfigurationProvider Build(ITypedConfigurationBuilder builder)
        {
            base.EnsureDefaults(builder);
            return new XmlTypedConfigurationProvider(this);
        }

    }
}
