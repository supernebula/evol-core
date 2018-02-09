//using AutoMapper;
//using AutoMapper.Configuration;
//using Evol.Domain.Dto;
//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Reflection;

//namespace Evol.Domain.Dto
//{
//    /// <summary>
//    /// object-object mapper , <see cref="IObjectMapExtensions"/>
//    /// AutoMapper每次调用 Mapper.Initialize() 都会创建新的 Mapper 实例，也就是多次调用 Mapper.Initialize() 只有最后一次生效。
//    /// 为了防止上次CreateMap()的Mapper实例丢失引起的config丢失，每次Initialize() 都是用相同的MapperConfiguration实例。MapperConfiguration
//    /// 负责存储所有的config信息。
//    /// </summary>
//    public class DtoObjectMapInitiator
//    {
//        private static MapperConfigurationExpression mapConfig;
//        static DtoObjectMapInitiator()
//        {
//            mapConfig = new MapperConfigurationExpression();
//        }

//        /// <summary>
//        /// object-object mapp（automapper）
//        /// </summary>
//        /// <param name="assembly"></param>
//        public static void Create(Assembly assembly)
//        {
//            var maplist = new List<MapSourceDestinationPair>();
//            var pairs1 = FindMapTo(assembly);
//            var pairs2 = FindMapFrom(assembly);
//            maplist.AddRange(pairs1);
//            maplist.AddRange(pairs2);

//            maplist.ForEach(pair => {
//                if (IsImplInterface(pair.Source, typeof(ICanConfigMapTo<>)))
//                {
//                    var dto = (ICanConfigMapTo)Activator.CreateInstance(pair.Source);
//                    dto.ConfigMap(mapConfig);
//                    return;
//                }

//                if (IsImplInterface(pair.Destination, typeof(ICanConfigMapFrom<>)))
//                {
//                    var dto = (ICanConfigMapFrom)Activator.CreateInstance(pair.Destination);
//                    dto.ConfigMap(mapConfig);
//                    return;
//                }

//                mapConfig.CreateMap(pair.Source, pair.Destination);
//            });
//        }

//        private static bool IsImplInterface(Type impl, Type interfaceTypeDef)
//        {
//            return impl.GetTypeInfo().ImplementedInterfaces.Any(i => i.GetTypeInfo().IsGenericType && i.GetGenericTypeDefinition() == interfaceTypeDef);
//        }

//        public static void Initialize()
//        {
//            Mapper.Initialize(mapConfig);
//        }

//        private static List<MapSourceDestinationPair> FindMapTo(Assembly assembly)
//        {
//            Func<Type, bool> filter = type =>
//            {
//                var tInfo = type.GetTypeInfo();
//                //return tInfo.IsPublic && !tInfo.IsAbstract && tInfo.IsClass && tInfo.GetInterfaces().Any(i => i.GetTypeInfo().IsGenericType && i.GetGenericTypeDefinition() == typeof(ICanMapTo<>));
//                var flag = tInfo.IsPublic && !tInfo.IsAbstract && tInfo.IsClass && tInfo.ImplementedInterfaces.Any(i => i.GetTypeInfo().IsGenericType && i.GetGenericTypeDefinition() == typeof(ICanConfigMapTo<>));
//                return flag;
//            };
//            var impls = assembly.GetTypes().Where(filter).ToList();
//            var sourceDestinationPairs = new List<MapSourceDestinationPair>();
//            if (impls.Count == 0)
//                return sourceDestinationPairs;
//            impls.ForEach(t =>
//            {
//                var @interfaces = t.GetTypeInfo().ImplementedInterfaces.Where(i => i.GetTypeInfo().IsGenericType && i.GetGenericTypeDefinition() == typeof(ICanConfigMapTo<>)).ToList();
//                var @interface = @interfaces.First();
//                sourceDestinationPairs.Add(new MapSourceDestinationPair() { Source = t, Destination = @interface.GenericTypeArguments.First() });
//            });
//            return sourceDestinationPairs;
//        }

//        private static List<MapSourceDestinationPair> FindMapFrom(Assembly assembly)
//        {
//            Func<Type, bool> filter = type =>
//            {
//                var tInfo = type.GetTypeInfo();
//                return tInfo.IsPublic && !tInfo.IsAbstract && tInfo.IsClass && tInfo.ImplementedInterfaces.Any(i => i.GetTypeInfo().IsGenericType && i.GetGenericTypeDefinition() == typeof(ICanConfigMapFrom<>));
//            };
//            var impls = assembly.GetTypes().Where(filter).ToList();
//            var sourceDestinationPairs = new List<MapSourceDestinationPair>();
//            if (impls.Count == 0)
//                return sourceDestinationPairs;
//            impls.ForEach(t =>
//            {
//                var @interfaces = t.GetTypeInfo().ImplementedInterfaces.Where(i => i.GetTypeInfo().IsGenericType && i.GetGenericTypeDefinition() == typeof(ICanConfigMapFrom<>)).ToList();
//                var @interface = @interfaces.First();
//                var source = @interface.GenericTypeArguments.First();
//                sourceDestinationPairs.Add(new MapSourceDestinationPair() { Source = source, Destination = t });
//            });
//            return sourceDestinationPairs;
//        }
//    }
//}
