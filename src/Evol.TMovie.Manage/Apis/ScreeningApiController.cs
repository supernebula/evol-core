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
    public class ScreeningApiController : ApiBaseController
    {
        public IScreeningQueryEntry ScreeningQueryEntry { get; set; }

        public ICommandBus CommandBus { get; set; }

        public ScreeningApiController(IScreeningQueryEntry screeningQueryEntry, ICommandBus commandBus)
        {
            ScreeningQueryEntry = screeningQueryEntry;
            CommandBus = commandBus;
        }

        // GET: api/Screening
        /// <summary>
        /// 查询影院场次列表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<ScreeningViewModel>> GetSearch([FromQuery]ScreeningQueryParameter param = null)
        {
            var list = await ScreeningQueryEntry.SelectAsync(param);
            var result = list.Map<List<ScreeningViewModel>>();
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
        public async Task<IPaged<ScreeningViewModel>> Get([FromQuery]ScreeningQueryParameter param = null, int pageIndex = 1, int pageSize = 10)
        {
            var paged = await ScreeningQueryEntry.PagedAsync(param, pageIndex, pageSize);
            var result = paged.MapPaged<ScreeningViewModel>();
            return result;
        }

        // GET: api/Screening/5
        /// <summary>
        /// 获取指定场次
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ScreeningViewModel> Get(Guid id)
        {
            var item = await ScreeningQueryEntry.FindAsync(id);
            var result = item.Map<ScreeningViewModel>();
            return result;
        }

        // POST: api/Screening
        /// <summary>
        /// 创建场次
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task Post(ScreeningCreateDto value)
        {
            ThrowIfNotModelIsValid();
            await CommandBus.SendAsync(new ScreeningCreateCommand { Input = value });
        }

        // PUT: api/Screening/5
        /// <summary>
        /// 更新场次
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        [HttpPut("{id}")]
        public async Task Put(int id, ScreeningUpdateDto value)
        {
            ThrowIfNotModelIsValid();
            await CommandBus.SendAsync(new ScreeningUpdateCommand { Input = value });
        }

        // DELETE: api/Screening/5
        /// <summary>
        /// 删除场次
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await CommandBus.SendAsync(new ScreeningDeleteCommand { Input = new ItemDeleteDto { Id = id } });
        }
    }
}
