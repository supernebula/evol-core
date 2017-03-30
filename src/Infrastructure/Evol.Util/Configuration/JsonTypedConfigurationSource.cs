using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace Evol.Util.Configuration
{
    public class JsonTypedConfigurationSource : FileTypedConfigurationSource
    {
        public JsonTypedConfigurationSource(Type strongType) : base(strongType)
        {

        }

        public override ITypedConfigurationProvider Build(ITypedConfigurationBuilder builder)
        {
            base.EnsureDefaults(builder);
            return new JsonTypedConfigurationProvider(this);
        }

    }
}
