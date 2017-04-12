using Evol.Domain;
using Evol.Domain.Uow;
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

        public EfUnitOfWorkDbContextProvider(IUnitOfWork uow)
        {
            UnitOfWork = uow;
        }

        public TDbContext Get<TDbContext>() where TDbContext : DbContext, INamedDbContext
        {
            var context = UnitOfWork.GetDbContext<TDbContext>();
            if (context != null)
                return context;
            context = AppConfig.Current.IoCManager.GetService<TDbContext>();
            UnitOfWork.AddDbContext(context.Name, context);
            return context;
        }
    }
}
