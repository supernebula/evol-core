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
using Evol.Common;
using Evol.TMovie.Domain.Commands.Dto;
using Evol.TMovie.Domain.Commands;
using Evol.TMovie.Domain.Dto;

namespace Evol.TMovie.Manage.Apis
{
    [Route("api/ScreenRoom")]
    public class ScreeningRoomApiController : ApiBaseController
    {
        public IScreeningRoomQueryEntry ScreenRoomQueryEntry { get; set; }

        public ICommandBus CommandBus { get; set; }

        public ScreeningRoomApiController(IScreeningRoomQueryEntry screenRoomQueryEntry, ICommandBus commandBus)
        {
            ScreenRoomQueryEntry = screenRoomQueryEntry;
            CommandBus = commandBus;
        }

        // GET: api/Screening
        /// <summary>
        /// 查询影院场次列表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<ScreeningRoomViewModel>> GetList([FromQuery]ScreeningRoomQueryParameter param = null)
        {
            var list = await ScreenRoomQueryEntry.SelectAsync(param);
            var result = list.Map<List<ScreeningRoomViewModel>>();
            return result;
        }

        // GET: api/Screening/Paged
        /// <summary>
        /// 分页查询影院场次列表
        /// </summary>
        /// <param name="param"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("Paged")]
        public async Task<IPaged<ScreeningRoomViewModel>> GetPaged([FromQuery]ScreeningRoomQueryParameter param = null, int pageIndex = 1, int pageSize = 10)
        {
            var paged = await ScreenRoomQueryEntry.PagedAsync(param, pageIndex, pageSize);
            var result = paged.MapPaged<ScreeningRoomViewModel>();
            return result;
        }

        // GET: api/Screening/5
        /// <summary>
        /// 获取指定场次
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ScreeningRoomViewModel> Get(Guid id)
        {
            var item = await ScreenRoomQueryEntry.FindAsync(id);
            var result = item.Map<ScreeningRoomViewModel>();
            return result;
        }

        // POST: api/Screening
        /// <summary>
        /// 创建场次
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task Post(ScreeningRoomCreateDto value)
        {
            ThrowIfNotModelIsValid();
            await CommandBus.SendAsync(new ScreeningRoomCreateCommand { Input = value });
        }

        // PUT: api/Screening/5
        /// <summary>
        /// 更新场次
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        [HttpPut("{id}")]
        public async Task Put(Guid id, ScreeningRoomUpdateDto value)
        {
            ThrowIfNotModelIsValid();
            await CommandBus.SendAsync(new ScreeningRoomUpdateCommand { Input = value });
        }

        // DELETE: api/Screening/5
        /// <summary>
        /// 删除场次
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await CommandBus.SendAsync(new ScreeningRoomDeleteCommand { Input = new ItemDeleteDto { Id = id } });
        }
    }
}
