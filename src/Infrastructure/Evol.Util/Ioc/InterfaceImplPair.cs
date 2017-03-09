using System;

namespace Evol.Util.Ioc
{
    public struct InterfaceImplPair
    {
        public bool Equals(InterfaceImplPair other)
        {
            return this == other;
        }

        public override bool Equals(object other)
        {
            return other is InterfaceImplPair && this == (InterfaceImplPair)other;
        }

        public override int GetHashCode()
        {
            return (Interface?.GetHashCode() ?? 0) ^ (Impl?.GetHashCode() ?? 0);
        }

        public Type Interface { get; set; }

        public Type Impl { get; set; }

        public static bool operator ==(InterfaceImplPair value1, InterfaceImplPair value2)
        {
            return value1.Interface == value2.Interface && value1.Impl == value2.Impl;
        }

        public static bool operator !=(InterfaceImplPair value1, InterfaceImplPair value2)
        {
            return value1.Interface != value2.Interface || value1.Impl != value2.Impl;
        }
    }
}
