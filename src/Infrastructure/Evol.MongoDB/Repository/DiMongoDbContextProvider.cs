using Evol.Common.IoC;
using System;

namespace Evol.MongoDB.Repository
{
    public class DiMongoDbContextProvider : IMongoDbContextProvider
    {
        private IIoCServiceGetter _serviceGetter;

        public DiMongoDbContextProvider(IIoCServiceGetter serviceGetter)
        {
            if (serviceGetter == null)
                throw new ArgumentNullException(nameof(serviceGetter));
            _serviceGetter = serviceGetter;
        }

        public NamedMongoDbContext Get<TDbContext>() where TDbContext : NamedMongoDbContext, new()
        {
            var context = _serviceGetter.GetService<TDbContext>();
            return context;
        }
    }
}
