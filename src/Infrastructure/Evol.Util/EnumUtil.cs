using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Evol.Util
{ 
    [Obsolete("未完成...")]
    public class EnumUtil
    {
        public static string GetDescription<TEnum>(TEnum enumValue) where TEnum : struct
        {
            var props = TypeDescriptor.GetProperties(enumValue.GetType());
            throw new NotImplementedException();  
        }
    }
}
