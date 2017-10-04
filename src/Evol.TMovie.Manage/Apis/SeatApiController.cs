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

namespace Evol.TMovie.Manage.Apis
{
    public class SeatApiController : BaseApiController
    {
        public ISeatQueryEntry SeatQueryEntry { get; set; }

        public ICommandBus CommandBus { get; set; }

        public SeatApiController(ISeatQueryEntry screeningQueryEntry, ICommandBus commandBus)
        {
            SeatQueryEntry = screeningQueryEntry;
            CommandBus = commandBus;
        }

        // GET: api/Seat
        /// <summary>
        /// 查询影院场次列表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<SeatViewModel>> GetSearch([FromQuery]SeatQueryParameter param = null)
        {
            var list = await SeatQueryEntry.SelectAsync(param);
            var result = list.Map<List<SeatViewModel>>();
            return result;
        }

        // GET: api/Seat/Paged
        /// <summary>
        /// 分页查询影院场次列表
        /// </summary>
        /// <param name="param"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("Paged")]
        public async Task<IPaged<SeatViewModel>> Get([FromQuery]SeatQueryParameter param = null, int pageIndex = 1, int pageSize = 10)
        {
            var paged = await SeatQueryEntry.PagedAsync(param, pageIndex, pageSize);
            var result = paged.MapPaged<SeatViewModel>();
            return result;
        }

        // GET: api/Seat/5
        /// <summary>
        /// 获取指定场次
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<SeatViewModel> Get(Guid id)
        {
            var item = await SeatQueryEntry.FindAsync(id);
            var result = item.Map<SeatViewModel>();
            return result;
        }

        // POST: api/Seat
        /// <summary>
        /// 创建场次
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task Post(SeatCreateDto value)
        {
            ThrowIfNotModelIsValid();
            await CommandBus.SendAsync(new SeatCreateCommand { Input = value });
        }

        // PUT: api/Seat/5
        /// <summary>
        /// 更新场次
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        [HttpPut("{id}")]
        public async Task Put(int id, SeatUpdateDto value)
        {
            ThrowIfNotModelIsValid();
            await CommandBus.SendAsync(new SeatUpdateCommand { Input = value });
        }

        // DELETE: api/Seat/5
        /// <summary>
        /// 删除场次
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await CommandBus.SendAsync(new SeatDeleteCommand { Input = new ItemDeleteDto { Id = id } });
        }
    }
}
