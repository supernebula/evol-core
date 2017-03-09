using System;

namespace Evol.Util.Expressions
{
    /// <summary>
    /// 默认常量验证器
    /// </summary>
    public class DefaultConstantValidtor : IConstantValidtor
    {
        public bool Validate(object value)
        {
            if (value == null)
                return false;
            if ((value is string) && string.IsNullOrWhiteSpace(value.ToString()))
                return false;
            if (value is Array && ((Array)value).Length == 0)
                return false;
            return true;
        }
    }
}
