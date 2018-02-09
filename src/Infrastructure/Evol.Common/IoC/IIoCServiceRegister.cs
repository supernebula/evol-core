using System;
using System.Collections.Generic;
using System.Text;

namespace Evol.Common.IoC
{
    public interface IIoCServiceRegister
    { 
        void AddPerDependency(Type @interface, Type Impl);

        void AddPerDependency<TInterface, TImpl>() where TImpl : TInterface;

        void AddPerRequest(Type @interface, Type Impl);

        void AddPerRequest<TInterface, TImpl>() where TImpl : TInterface;

        void AddSingleInstance(Type @interface, Type Impl);

        void AddSingleInstance<TInterface, TImpl>() where TImpl : TInterface;

        void AddSingleInstance<TInterface>(TInterface instance);
    }
}
