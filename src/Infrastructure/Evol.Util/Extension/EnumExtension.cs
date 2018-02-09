using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Linq;


namespace Evol.Util.Extension
{ 
    public static class EnumExtension
    {

        public static string GetDescription<TEnum>(this TEnum enumValue) where TEnum : struct
        {
            var valDesDic = GetValueDescriptionDic<TEnum>();
            string description;
            valDesDic.TryGetValue(enumValue, out description);
            return description;
        }

        public static Dictionary<object, string> GetValueDescriptionDic<TEnum>() where TEnum : struct
        {
            var type = typeof(TEnum);
            var valDesDic = new Dictionary<object, string>();
            var values = Enum.GetValues(type);
            var fieldInfos = type.GetTypeInfo().GetFields();
            foreach (var val in values)
            {
                var name = Enum.GetName(type, val);
                var field = fieldInfos.SingleOrDefault(e => e.Name == name);
                var desAttr = field.GetCustomAttribute<DescriptionAttribute>();
                if (desAttr == null)
                    valDesDic.Add(val, Enum.GetName(type, val));
                else
                    valDesDic.Add(val, desAttr.Description);
            }
            return valDesDic;
        }



        public static Dictionary<string, string> GetNameDescriptionDic<TEnum>() where TEnum : struct
        {
            var type = typeof(TEnum);
            var nameDesDic = new Dictionary<string, string>();
            var names = Enum.GetNames(type);
            var fieldInfos = type.GetTypeInfo().GetFields();
            foreach (var name in names)
            {
                var field = fieldInfos.SingleOrDefault(e => e.Name == name);
                var desAttr = field.GetCustomAttribute<DescriptionAttribute>();
                nameDesDic.Add(name, desAttr?.Description);
            }
            return nameDesDic;
        }

    }
}
