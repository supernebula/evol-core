using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Evol.Common;
using Evol.TMovie.Domain.Models.AggregateRoots;
using Evol.TMovie.Domain.QueryEntries;
using Evol.TMovie.Domain.QueryEntries.Parameters;
using Evol.TMovie.Domain.Repositories;


namespace Evol.TMovie.Data.QueryEntries
{
    public class UserQueryEntry : IUserQueryEntry
    {
        private IUserRepository _userRepository { get; set; }
        public UserQueryEntry(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User> FetchAsync(Guid id)
        {
            return await _userRepository.FindAsync(id);
        }

        public async Task<List<User>> GetByIdsAsync(Guid[] ids)
        {
            return (await _userRepository.RetrieveAsync(e => ids.Contains(e.Id))).ToList();
        }

        public async Task<List<User>> RetrieveAsync(UserQueryParameter param)
        {
            if (param == null)
                throw new ArgumentNullException(nameof(param));
            if (param.Key == null)
                throw new ArgumentNullException((nameof(param.Key)));

            var list = (await _userRepository.RetrieveAsync(e => e.Username.StartsWith(param.Key) || e.RealName.StartsWith(param.Key) || e.Mobile.StartsWith(param.Key) || e.Email.StartsWith(param.Key))).ToList();
            return list;
        }

        public async Task<IPaged<User>> PagedAsync(UserQueryParameter param, int pageIndex, int pageSize)
        {
            if (param == null)
                throw new ArgumentNullException(nameof(param));
            if (param.Key == null)
                throw new ArgumentNullException((nameof(param.Key)));

            var result = await _userRepository.PagedAsync(e => e.Username.StartsWith(param.Key) || e.RealName.StartsWith(param.Key) || e.Mobile.StartsWith(param.Key) || e.Email.StartsWith(param.Key), pageIndex, pageSize);
            return result;
        }
    }
}
