using Evol.MongoDB.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Evol.TMovie.Manage.Extensions.DependencyInjection
{
    public static class MongoDBServiceCollectionExtensions
    {
        public static IServiceCollection AddMongoDbContext<TContext>(
            this IServiceCollection services, 
            Action<MongoDbContextOptionsBuilder<TContext>> optionsAction, 
            ServiceLifetime contextLifetime = ServiceLifetime.Scoped)
            where TContext : NamedMongoDbContext
        {
            var builder = new MongoDbContextOptionsBuilder<TContext>();
            //services.AddTransient<MongoDbContextOptionsBuilder<TContext>>(serviceProvider => optionsAction.Invoke(builder));
            services.AddScoped<TContext, TContext>();
            return services;
        }
    }
}
