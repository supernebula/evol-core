using Evol.MongoDB.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evol.TMovie.Manage.Extensions.DependencyInjection
{
    public static class MongoDBServiceCollectionExtensions
    {

        public static IServiceCollection AddMongoDbContext<TContext>(this IServiceCollection serviceCollection, /*[CanBeNullAttribute]*/ Action<MongoDbContextOptionsBuilder<TContext>> optionsAction = null, ServiceLifetime contextLifetime = ServiceLifetime.Scoped) where TContext : NamedMongoDbContext
        {
            throw new NotImplementedException();
        }

        //public static IServiceCollection AddDbContext<TContext>([NotNullAttribute] this IServiceCollection serviceCollection, ServiceLifetime contextLifetime) where TContext : DbContext;

        //public static IServiceCollection AddDbContext<TContext>([NotNullAttribute] this IServiceCollection serviceCollection, [CanBeNullAttribute] Action<IServiceProvider, DbContextOptionsBuilder> optionsAction, ServiceLifetime contextLifetime = ServiceLifetime.Scoped) where TContext : DbContext;
    }
}
