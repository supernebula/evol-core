using AutoMapper;
using AutoMapper.Configuration;
using Evol.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Evol.TMovie.Domain.Dto
{
    /// <summary>
    /// object-object mapper , <see cref="IObjectMapExtensions"/>
    /// AutoMapper每次调用 Mapper.Initialize() 都会创建新的 Mapper 实例，也就是多次调用 Mapper.Initialize() 只有最后一次生效。
    /// 为了防止上次CreateMap()的Mapper实例丢失引起的config丢失，每次Initialize() 都是用相同的MapperConfiguration实例。MapperConfiguration
    /// 负责存储所有的config信息。
    /// </summary>
    public class DtoObjectMapInitiator
    {
        private static MapperConfigurationExpression mapConfig;
        static DtoObjectMapInitiator()
        {
            mapConfig = new MapperConfigurationExpression();
        }

        /// <summary>
        /// object-object mapp（automapper）
        /// </summary>
        /// <param name="assembly"></param>
        public static void Create(Assembly assembly)
        {
            var maplist = new List<MapSourceDestinationPair>();
            var pairs1 = FindMapTo(assembly);
            var pairs2 = FindMapFrom(assembly);
            maplist.AddRange(pairs1);
            maplist.AddRange(pairs2);

            maplist.ForEach(pair => {
                mapConfig.CreateMap(pair.Source, pair.Destination);
            });
            
        }

        public static void Initialize()
        {
            Mapper.Initialize(mapConfig);
        }

        private static List<MapSourceDestinationPair> FindMapTo(Assembly assembly)
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

        private static List<MapSourceDestinationPair> FindMapFrom(Assembly assembly)
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
