using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evol.EntityFramework.Repository
{
    public class DbContextProxy
    {
        public DbContext DbContext()
        {
            throw new NotImplementedException();
        }

        public bool IsDbContextCreated => null != DbContext();

        public void WaitUntilDbContextCreated(Action<DbContext> action)
        {
            var dbContext = DbContext();
            if(dbContext == null)
                DbContextCreatedEvent += new OnDbContentCreated(action);

            DbContextCreatedEvent?.Invoke(dbContext);
            action?.Invoke(dbContext);
        }

        private delegate void OnDbContentCreated(DbContext dbContext);
        private event OnDbContentCreated DbContextCreatedEvent;
    }
}
