using System;
using Evol.EntityFramework.Repository.Test.QueryEntries.Parameters;
using Evol.Test.Model;

namespace Evol.EntityFramework.Repository.Test.QueryEntries
{
    public class UserQueryEntry
    {
        public FakeUser Find(Guid id)
        {
            throw new NotImplementedException();
        }

        public FakeUser FindAlone(Guid id)
        {
            throw new NotImplementedException();
        }

        public FakeUser Retrieve(UserQueryParameter param)
        {
            throw new NotImplementedException();
        }

        public FakeUser RetrieveAlone(UserQueryParameter param)
        {
            throw new NotImplementedException();
        }
    }
}
