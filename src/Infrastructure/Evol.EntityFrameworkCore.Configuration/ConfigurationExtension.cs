using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;

namespace Evol.EntityFrameworkCore.Configuration
{
    public static class ConfigurationExtension
    {
        public static void AddConfiguration<TEntityConfigMap>(this ModelBuilder modelBuilder) where TEntityConfigMap : EntityConfigMap, new()
        {
            new TEntityConfigMap().Map(modelBuilder);
        }

        public static void AddConfigurationFromAssembly(this ModelBuilder modelBuilder, Assembly assembly)
        {
            var types = assembly.GetTypes();
            var entityMapTypes = types.Where(e =>
            {
                var baseType = e.GetTypeInfo().BaseType;
                return baseType.GetTypeInfo().IsGenericType && baseType.GetGenericTypeDefinition() == typeof(EntityConfigMap<>);
            }).ToList();
            entityMapTypes.ForEach(t => {
                var entityMap = (EntityConfigMap)Activator.CreateInstance(t);
                entityMap.Map(modelBuilder);
            });
        }
    }
}
