using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace Evol.Domain.Uow
{
    public class UnitOfWorkBuild
    {

        private static IUnitOfWorkManager UowManager
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public static IOptionUnitOfWork Create()
        {
            UowManager
        }

        public static IOptionUnitOfWork Create(IsolationLevel isolationLevel)
        {

        }


        public static Task BeginAsync(Action action)
        {
            action.Invoke();
        }

        public static Task<TR> BeginAsyncc<TR>(Func<TR> func)
        {
            func.Invoke();
        }
    }
}
