using AutoMapper;
using Evol.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Evol.TMovie.Domain.Dto
{
    /// <summary>
    /// object-object mapper , <see cref="IObjectMapExtensions"/>
    /// </summary>
    public class ObjectToObjectMapInitiator
    {
        /// <summary>
        /// object-object mapp（automapper）
        /// </summary>
        /// <param name="assembly"></param>
        public void Init(Assembly assembly)
        {
            var maplist = new List<MapSourceDestinationPair>();
            var pairs1 = FindMapTo(assembly);
            var pairs2 = FindMapFrom(assembly);
            maplist.AddRange(pairs1);
            maplist.AddRange(pairs2);

            maplist.ForEach(pair => {
                Mapper.Initialize(cfg => cfg.CreateMap(pair.Source, pair.Destination));
            });
        }

        private List<MapSourceDestinationPair> FindMapTo(Assembly assembly)
        {
            Func<Type, bool> filter = type =>
            {
                var tInfo = type.GetTypeInfo();
                return tInfo.IsPublic && !tInfo.IsAbstract && tInfo.IsClass && tInfo.GetInterfaces().Any(i => i.GetTypeInfo().IsGenericType && i.GetGenericTypeDefinition() == typeof(ICanMapTo<>));
            };
            var impls = assembly.GetTypes().Where(filter).ToList();
            var sourceDestinationPairs = new List<MapSourceDestinationPair>();
            if (impls.Count == 0)
                return sourceDestinationPairs;
            impls.ForEach(t =>
            {
                var @interfaces = t.GetTypeInfo().GetInterfaces().Where(i => i.GetTypeInfo().IsGenericType && i.GetGenericTypeDefinition() == typeof(ICanMapTo<>)).ToList();
                var @interface = @interfaces.First();
                sourceDestinationPairs.Add(new MapSourceDestinationPair() { Source = t, Destination = @interface.GenericTypeArguments.First() });
            });
            return sourceDestinationPairs;
        }

        private List<MapSourceDestinationPair> FindMapFrom(Assembly assembly)
        {
            Func<Type, bool> filter = type =>
            {
                var tInfo = type.GetTypeInfo();
                return tInfo.IsPublic && !tInfo.IsAbstract && tInfo.IsClass && tInfo.GetInterfaces().Any(i => i.GetTypeInfo().IsGenericType && i.GetGenericTypeDefinition() == typeof(ICanMapFrom<>));
            };
            var impls = assembly.GetTypes().Where(filter).ToList();
            var sourceDestinationPairs = new List<MapSourceDestinationPair>();
            if (impls.Count == 0)
                return sourceDestinationPairs;
            impls.ForEach(t =>
            {
                var @interfaces = t.GetTypeInfo().GetInterfaces().Where(i => i.GetTypeInfo().IsGenericType && i.GetGenericTypeDefinition() == typeof(ICanMapFrom<>)).ToList();
                var @interface = @interfaces.First();
                var source = @interface.GenericTypeArguments.First();
                sourceDestinationPairs.Add(new MapSourceDestinationPair() { Source = source, Destination = t });
            });
            return sourceDestinationPairs;
        }
    }
}
