using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data.Linq;
using System.Data;
using System.Text.RegularExpressions;
using System.Collections;
using System.Reflection;

namespace TestLINQ
{
    public static class ObjectConverter
    {
        private class CommonProperty
        {
            public PropertyInfo SourceProperty { get; set; }
            public PropertyInfo TargetProperty { get; set; }
        }

        private static class PropertyCache
        {
            private static object syncProperty = new object();
            private static object syncCommon = new object();

            private static Dictionary<Type, PropertyInfo[]> PropertyDictionary =
                new Dictionary<Type, PropertyInfo[]>(); //缓存类型的PropertyInfo数组
            private static Dictionary<string, IEnumerable<CommonProperty>> CommonPropertyDictionary =
                new Dictionary<string, IEnumerable<CommonProperty>>(); //缓存两种类型的公共属性对应关系

            private static PropertyInfo[] GetPropertyInfoArray(Type type)
            {
                if (!PropertyCache.PropertyDictionary.ContainsKey(type))
                {
                    lock (syncProperty)
                    {
                        if (!PropertyCache.PropertyDictionary.ContainsKey(type)) //双重检查
                        {
                            PropertyInfo[] properties = type.GetProperties();
                            PropertyCache.PropertyDictionary.Add(type, properties); //Type是单例的(Singleton)，可以直接作为Key
                        }
                    }
                }
                return PropertyCache.PropertyDictionary[type];
            }

            public static IEnumerable<CommonProperty> GetCommonProperties(Type sourceType, Type targetType)
            {
                string key = sourceType.ToString() + targetType.ToString();
                if (!PropertyCache.CommonPropertyDictionary.ContainsKey(key))
                {
                    lock (syncCommon)
                    {
                        if (!PropertyCache.CommonPropertyDictionary.ContainsKey(key)) //双重检查
                        {
                            PropertyInfo[] sourceTypeProperties = PropertyCache.GetPropertyInfoArray(sourceType);//获取源对象所有属性
                            PropertyInfo[] targetTypeProperties = PropertyCache.GetPropertyInfoArray(targetType); //获取目标对象所有属性
                            return from SP in sourceTypeProperties
                                   join TP in targetTypeProperties
                                      on SP.Name.ToLower() equals TP.Name.ToLower() //根据属性名进行对应(不区分大小写)
                                   select new CommonProperty
                                   {
                                       SourceProperty = SP,
                                       TargetProperty = TP
                                   };
                        }
                    }
                }
                return PropertyCache.CommonPropertyDictionary[key];
            }
        }

        /// <summary>
        /// happyhippy Extension:将原集合转换为目标集合
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static List<TResult> ConvertTo<TResult>(this IEnumerable source)
            where TResult : new()
        {
            if (source == null) //啥都不用干
                return null;

            if (source is IEnumerable<TResult>)
                return source.Cast<TResult>().ToList();//源类型于目标类型一致，可以直接转换

            List<TResult> result = new List<TResult>();
            bool hasGetElementType = false;
            IEnumerable<CommonProperty> commonProperties = null; //公共属性(按属性名称进行匹配)

            foreach (var s in source)
            {
                if (!hasGetElementType) //访问第一个元素时，取得属性对应关系；后续的元素就不用再重新计算了
                {
                    if (s is TResult) //如果源类型是目标类型的子类，可以直接Cast<T>扩展方法
                    {
                        return source.Cast<TResult>().ToList();
                    }
                    commonProperties = PropertyCache.GetCommonProperties(s.GetType(), typeof(TResult));
                    hasGetElementType = true;
                }

                TResult t = new TResult();
                foreach (CommonProperty commonProperty in commonProperties) //逐个属性拷贝
                {
                    object value = commonProperty.SourceProperty.GetValue(s, null);
                    commonProperty.TargetProperty.SetValue(t, value, null);
                }
                result.Add(t);
            }

            return result;
        }
    }
}
