using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Evol.Logging.AdapteNLog
{
    internal static class DictionaryObjectConvert
    {
        /// <summary>
        /// 契约对象转排序字典
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static SortedDictionary<string, string> DictionarySimpleContractConvert(object obj)
        {
            var dic = new SortedDictionary<string, string>();
            var propertiesps = TypeDescriptor.GetProperties(obj.GetType());

            foreach (PropertyDescriptor prop in propertiesps)
            {
                var value = prop.GetValue(obj);
                dic.Add(prop.Name, value == null ? String.Empty : value.ToString());
            }
            return dic;
        }
    }
}
