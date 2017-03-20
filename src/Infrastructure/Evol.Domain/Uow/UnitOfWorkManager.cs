using System;
using System.Collections.Generic;
using System.Text;

namespace Evol.Domain.Uow
{
    public class UnitOfWorkManager : IUnitOfWorkManager
    {
        private Func<IUnitOfWork> NewUowThunk = () => { throw new NotImplementedException(); };
        public UnitOfWorkManager()
        {

        }

        private IUnitOfWork _current;


        public IUnitOfWork Current
        {
            get
            {
                return _current;
            }

            set
            {
                if (_current != null)
                {
                    value.Outer = _current;
                    _current = value;
                }
                else
                {
                    _current = _current.Outer;
                }
                    
            }
        }

        public IUnitOfWorkToComplete Begin()
        {
            return Begin(new UnitOfWorkOption());
        }

        public IUnitOfWorkToComplete Begin(UnitOfWorkOption option)
        {
            var uow = NewUowThunk.Invoke();


            uow.Committed += (sender, args) =>
            {
                Current = null;
            };

            uow.Failed += (sender, args) =>
            {
                Current = null;
            };

            uow.Disposed += (sender, args) =>
            {
                //Release the objects in the IOC container
            };

            uow.Begin(option);
            return uow;
        }

    }
}
