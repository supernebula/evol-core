using Evol.Domain.Messaging;
using Evol.TMovie.Domain.QueryEntries;
using Evol.TMovie.Domain.QueryEntries.Parameters;
using Evol.TMovie.Manage.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Evol.Domain.Dto;
using Evol.TMovie.Domain.Commands.Dto;
using Evol.TMovie.Domain.Commands;

namespace Evol.TMovie.Manage.Apis
{
    /// <summary>
    /// 座位管理 API
    /// </summary>
    [Route("api/Seat")]
    public class SeatApiController : ApiBaseController
    {
        public ISeatQueryEntry SeatQueryEntry { get; set; }

        public ICommandBus CommandBus { get; set; }

        public SeatApiController(ISeatQueryEntry screeningQueryEntry, ICommandBus commandBus)
        {
            SeatQueryEntry = screeningQueryEntry;
            CommandBus = commandBus;
        }

        // GET: api/Seat/all
        /// <summary>
        /// 查询座位列表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpGet("All")]
        public async Task<List<SeatViewModel>> GetAll([FromQuery]SeatQueryParameter param = null)
        {
            var list = await SeatQueryEntry.SelectAsync(param);
            var result = list.MapList<SeatViewModel>();
            return result;
        }

        // GET: api/Seat/5
        /// <summary>
        /// 获取指定座位
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


        // PUT: api/Seat/5
        /// <summary>
        /// 变更场次座位
        /// </summary>
        /// <param name="roomId">screenRoomId</param>
        /// <param name="value"></param>
        [HttpPut]
        public async Task Put(Guid roomId, [FromBody]SeatChangeDto value)
        {
            ThrowIfNotModelIsValid();
            await CommandBus.SendAsync(new SeatChangeCommand { Input = value });
        }

    }
}
