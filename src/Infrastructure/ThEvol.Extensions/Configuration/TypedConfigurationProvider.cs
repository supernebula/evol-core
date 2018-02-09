using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Primitives;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using System.IO;
using System.Threading;

namespace Evol.Extensions.Configuration
{
    /// <summary>
    /// Base helper class for implementing an <see cref="ITypedConfigurationProvider"/>
    /// </summary>
    public abstract class TypedConfigurationProvider : ITypedConfigurationProvider
    {
        private ConfigurationReloadToken _reloadToken = new ConfigurationReloadToken();

        public abstract Type StrongType { get; }

        /// <summary>
        /// Initializes a new <see cref="IConfigurationProvider"/>
        /// </summary>
        protected TypedConfigurationProvider()
        {

        }


        public bool TryGet<T>(out T value) where T : class
        {
            return ((value = Data as T) != null);
        }

        public object GetValue()
        {
            return Data;
        }
        /// <summary>
        /// The configuration Deserialize(or parse ) strong type object for this provider.
        /// </summary>
        protected object Data { get; set; }

        

        /// <summary>
        /// Loads (or reloads) the data for this provider.
        /// </summary>
        public virtual void Load()
        {
        }


        /// <summary>
        /// Returns a <see cref="IChangeToken"/> that can be used to listen when this provider is reloaded.
        /// </summary>
        /// <returns></returns>
        public IChangeToken GetReloadToken()
        {
            return _reloadToken;
        }

        /// <summary>
        /// Triggers the reload change token and creates a new one.
        /// </summary>
        protected void OnReload()
        {
            var previousToken = Interlocked.Exchange(ref _reloadToken, new ConfigurationReloadToken());
            previousToken.OnReload();
        }


    }
}
