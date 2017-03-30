using System;

namespace Evol.Util.Configuration.Xml
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
