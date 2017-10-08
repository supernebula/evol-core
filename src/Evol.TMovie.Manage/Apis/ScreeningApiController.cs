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
    /// <summary>
    /// 场次管理 API
    /// </summary>
    [Route("api/Schedule")]
    public class ScheduleApiController : ApiBaseController
    {
        public IScheduleQueryEntry ScheduleQueryEntry { get; set; }

        public ICommandBus CommandBus { get; set; }

        public ScheduleApiController(IScheduleQueryEntry scheduleQueryEntry, ICommandBus commandBus)
        {
            ScheduleQueryEntry = scheduleQueryEntry;
            CommandBus = commandBus;
        }

        // GET: api/Schedule
        /// <summary>
        /// 查询影院场次列表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<ScheduleViewModel>> GetList([FromQuery]ScheduleQueryParameter param = null)
        {
            var list = await ScheduleQueryEntry.SelectAsync(param);
            var result = list.Map<List<ScheduleViewModel>>();
            return result;
        }

        // GET: api/Schedule/Paged
        /// <summary>
        /// 分页查询影院场次列表
        /// </summary>
        /// <param name="param"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("Paged")]
        public async Task<IPaged<ScheduleViewModel>> GetPaged([FromQuery]ScheduleQueryParameter param = null, int pageIndex = 1, int pageSize = 10)
        {
            var paged = await ScheduleQueryEntry.PagedAsync(param, pageIndex, pageSize);
            var result = paged.MapPaged<ScheduleViewModel>();
            return result;
        }

        // GET: api/Screening/5
        /// <summary>
        /// 获取指定场次
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ScheduleViewModel> Get(Guid id)
        {
            var item = await ScheduleQueryEntry.FindAsync(id);
            var result = item.Map<ScheduleViewModel>();
            return result;
        }

        // POST: api/Screening
        /// <summary>
        /// 创建场次
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task Post(ScheduleCreateDto value)
        {
            ThrowIfNotModelIsValid();
            await CommandBus.SendAsync(new ScheduleCreateCommand { Input = value });
        }

        // PUT: api/Schedule/5
        /// <summary>
        /// 更新场次
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        [HttpPut("{id}")]
        public async Task Put(Guid id, ScheduleUpdateDto value)
        {
            ThrowIfNotModelIsValid();
            await CommandBus.SendAsync(new ScheduleUpdateCommand { Input = value });
        }

        // DELETE: api/Schedule/5
        /// <summary>
        /// 删除场次
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await CommandBus.SendAsync(new ScheduleDeleteCommand { Input = new ItemDeleteDto { Id = id } });
        }
    }
}
