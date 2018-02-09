using System.Collections.Generic;

namespace Evol.Common.Logging
{
    public class LogPropInfo<T>
    {
        public LogPropInfo(T model)
        {
            Model = model;
            PropNameValues = new Dictionary<string, object>();
        }

        public T Model { get; private set; }

        public Dictionary<string, object> PropNameValues { get; private set; }

        public object this[string key]
        {
            get
            {
                if (PropNameValues.ContainsKey(key))
                    return PropNameValues[key];
                return default(object);
            }
            set
            {
                if (PropNameValues.ContainsKey(key))
                {
                    PropNameValues[key] = value;
                    return;
                }

                PropNameValues.Add(key, value);
            }
        }
    }
}
