using Evol.Domain;
using Evol.Domain.Uow;
using Evol.EntityFramework.Uow;
using Microsoft.EntityFrameworkCore;
using System;

namespace Evol.EntityFramework.Repository
{
    public class EfUnitOfWorkDbContextProvider : IEfDbContextProvider
    {
        public IActiveUnitOfWork UnitOfWork
        {
            get;
            set;
        }

        //public EfUnitOfWorkDbContextProvider(IUnitOfWork uow)
        //{
        //    UnitOfWork = uow;
        //}

        public EfUnitOfWorkDbContextProvider(IUnitOfWorkManager uowManager)
        {
            UnitOfWork = uowManager.Current;
        }

        public TDbContext Get<TDbContext>() where TDbContext : DbContext
        {
            TDbContext context;
            if (UnitOfWork == null)
            {
                context = AppConfig.Current.IoCManager.GetService<TDbContext>();
                return context;
            }

            context = UnitOfWork.GetDbContext<TDbContext>();
            if (context != null)
                return context;
            context = AppConfig.Current.IoCManager.GetService<TDbContext>();
            UnitOfWork.AddDbContext(context);
            return context;
        }
    }
}
