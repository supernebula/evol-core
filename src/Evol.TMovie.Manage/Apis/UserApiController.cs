using Evol.Common;
using Evol.Domain.Messaging;
using Evol.TMovie.Domain.QueryEntries;
using Evol.TMovie.Domain.QueryEntries.Parameters;
using Evol.TMovie.Manage.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Evol.Domain.Dto;
using Evol.TMovie.Domain.Commands.Dto;
using Evol.TMovie.Domain.Commands;
using Evol.TMovie.Domain.Dto;

namespace Evol.TMovie.Manage.Apis
{
    [Route("api/user")]
    public class UserApiController : ApiBaseController
    {
        public IUserQueryEntry UserQueryEntry { get; set; }

        public ICommandBus CommandBus { get; set; }

        public UserApiController(IUserQueryEntry userQueryEntry, ICommandBus commandBus)
        {
            UserQueryEntry = userQueryEntry;
            CommandBus = commandBus;
        }

        // GET: api/User
        /// <summary>
        /// 查询影院列表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<UserViewModel>> GetList([FromQuery]UserQueryParameter param = null)
        {
            var list = await UserQueryEntry.SelectAsync(param);
            var result = list.Map<List<UserViewModel>>();
            return result;
        }

        // GET: api/User/Paged
        /// <summary>
        /// 分页查询影院列表
        /// </summary>
        /// <param name="param"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("Paged")]
        public async Task<IPaged<UserViewModel>> GetPaged([FromQuery]UserQueryParameter param = null, int pageIndex = 1, int pageSize = 10)
        {
            var paged = await UserQueryEntry.PagedAsync(param, pageIndex, pageSize);
            var result = paged.MapPaged<UserViewModel>();
            return result;
        }

        // GET: api/User/5
        /// <summary>
        /// 获取指定影院
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<UserViewModel> Get(Guid id)
        {
            var item = await UserQueryEntry.FindAsync(id);
            var result = item.Map<UserViewModel>();
            return result;
        }

        // POST: api/User
        /// <summary>
        /// 创建影院
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task Post(UserCreateDto value)
        {
            ThrowIfNotModelIsValid();

            await CommandBus.SendAsync(new UserCreateCommand { Input = value });
        }

        // PUT: api/User/5
        /// <summary>
        /// 更新影院
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        [HttpPut("{id}")]
        public async Task Put(Guid id, UserUpdateDto value)
        {
            ThrowIfNotModelIsValid();
            await CommandBus.SendAsync(new UserUpdateCommand { Input = value });
        }

        // DELETE: api/User/5
        /// <summary>
        /// 删除影院
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await CommandBus.SendAsync(new UserDeleteCommand { Input = new ItemDeleteDto { Id = id } });
        }
    }
}
