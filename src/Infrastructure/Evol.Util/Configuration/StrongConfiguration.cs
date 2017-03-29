using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Primitives;
using System.Threading;
using Microsoft.Extensions.Configuration;

namespace Evol.Util.Configuration
{
    public class StrongConfiguration : IStrongConfiguration
    {
        private IStrongConfigurationProvider _configProvider;

        private ConfigurationReloadToken _changeToken = new ConfigurationReloadToken();

        public StrongConfiguration(IStrongConfigurationProvider configurationProvider)
        {
            _configProvider = configurationProvider;
            _configProvider.Load();
            ChangeToken.OnChange(() => _configProvider.GetReloadToken(), delegate { });


        }
        public IChangeToken GetReloadToken()
        {
            return this._changeToken;
        }

        public T GetValue<T>()
        {
            throw new NotImplementedException();
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
