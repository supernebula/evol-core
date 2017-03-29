using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Primitives;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using System.IO;
using System.Threading;

namespace Evol.Util.Configuration
{
    public abstract class FileStrongConfigurationProvider : IStrongConfigurationProvider
    {


        private ConfigurationReloadToken _reloadToken = new ConfigurationReloadToken();

        protected string Content { get; set; }

        public FileStrongConfigurationSource Source { get; }

        public FileStrongConfigurationProvider(FileStrongConfigurationSource source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            this.Source = source;
            if (this.Source.ReloadOnChange && this.Source.FileProvider != null)
            {
                ChangeToken.OnChange(() => this.Source.FileProvider.Watch(this.Source.Path), delegate
                {
                    Thread.Sleep(this.Source.ReloadDelay);
                    this.Load(true);
                });
            }
        }


        public IChangeToken GetReloadToken()
        {
            return this._reloadToken;
        }

        public virtual void Load()
        {
        }


        private void Load(bool reload)
        {
            IFileProvider provider = this.Source.FileProvider;
            IFileInfo fileInfo = (provider != null) ? provider.GetFileInfo(this.Source.Path) : null;
            if (fileInfo == null || !fileInfo.Exists)
            {
                if (!(this.Source.Optional | reload))
                {
                    StringBuilder stringBuilder = new StringBuilder(string.Format("The configuration file '{0}' was not found and is not optional.", this.Source.Path));
                    if (!string.IsNullOrEmpty((fileInfo != null) ? fileInfo.PhysicalPath : null))
                    {
                        stringBuilder.Append(string.Format(" The physical path is '{0}'.", fileInfo.PhysicalPath));
                    }
                    throw new FileNotFoundException(stringBuilder.ToString());
                }

                Content = string.Empty;
                //base.Data = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            }
            else
            {
                if (reload)
                {
                    Content = string.Empty;
                    //base.Data = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                }
                using (Stream stream = fileInfo.CreateReadStream())
                {
                    try
                    {
                        this.Load(stream);
                    }
                    catch (Exception ex)
                    {
                        bool flag = false;
                        if (this.Source.OnLoadException != null)
                        {
                            FileLoadExceptionContext fileLoadExceptionContext = new FileLoadExceptionContext
                            {
                                //Provider = this,
                                Exception = ex
                            };
                            this.Source.OnLoadException.Invoke(fileLoadExceptionContext);
                            flag = fileLoadExceptionContext.Ignore;
                        }
                        if (!flag)
                        {
                            throw ex;
                        }
                    }
                }
            }
            base.OnReload();
        }

        public abstract void Load(Stream stream);

        public abstract bool TryGet<T>(out T value);


        
    }
}
