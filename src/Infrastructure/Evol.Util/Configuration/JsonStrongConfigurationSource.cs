using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace Evol.Util.Configuration
{
    class JsonStrongConfigurationSource : FileStrongConfigurationSource
    {
        public override Type StrongType { get;}

        public override IStrongConfigurationProvider Build(IStrongConfigurationBuilder builder)
        {
            base.EnsureDefaults(builder);
            return new JsonStrongConfigurationProvider(this);
        }

        public override IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            throw new NotImplementedException();
        }
    }
}
