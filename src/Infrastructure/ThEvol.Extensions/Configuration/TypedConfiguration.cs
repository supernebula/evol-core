using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Primitives;
using System.Threading;
using Microsoft.Extensions.Configuration;

namespace Evol.Extensions.Configuration
{
    public class TypedConfiguration : ITypedConfiguration
    {
        private ITypedConfigurationProvider _configProvider;

        private ConfigurationReloadToken _changeToken = new ConfigurationReloadToken();

        public TypedConfiguration(ITypedConfigurationProvider configurationProvider)
        {
            _configProvider = configurationProvider;
            _configProvider.Load();
            ChangeToken.OnChange(() => _configProvider.GetReloadToken(), delegate { });


        }

        public Type StrongType
        {
            get
            {
                return _configProvider.StrongType;
            }
        }

        public ITypedConfigurationSource Source { get; private set; }

        public object GetValue()
        {
            return _configProvider.GetValue();
        }

       

        public IChangeToken GetReloadToken()
        {
            return this._changeToken;
        }


        public void Reload()
        {
            _configProvider.Load();
            
        }

        private void RaiseChanged()
        {
            Interlocked.Exchange<ConfigurationReloadToken>(ref this._changeToken, new ConfigurationReloadToken()).OnReload();
        }
    }
}
