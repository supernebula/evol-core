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
    [Route("api/Order")]
    public class OrderApiController : ApiBaseController
    {
        public IOrderQueryEntry OrderQueryEntry { get; set; }

        public ICommandBus CommandBus { get; set; }

        public OrderApiController(IOrderQueryEntry orderQueryEntry, ICommandBus commandBus)
        {
            OrderQueryEntry = orderQueryEntry;
            CommandBus = commandBus;
        }

        // GET: api/Order
        /// <summary>
        /// 查询影院列表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<OrderViewModel>> GetList([FromQuery]OrderQueryParameter param = null)
        {
            var list = await OrderQueryEntry.SelectAsync(param);
            var result = list.Map<List<OrderViewModel>>();
            return result;
        }

        // GET: api/Order/Paged
        /// <summary>
        /// 分页查询影院列表
        /// </summary>
        /// <param name="param"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("Paged")]
        public async Task<IPaged<OrderViewModel>> GetPaged([FromQuery]OrderQueryParameter param = null, int pageIndex = 1, int pageSize = 10)
        {
            var paged = await OrderQueryEntry.PagedAsync(param, pageIndex, pageSize);
            var result = paged.MapPaged<OrderViewModel>();
            return result;
        }

        // GET: api/Order/5
        /// <summary>
        /// 获取指定影院
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<OrderViewModel> Get(Guid id)
        {
            var item = await OrderQueryEntry.FindAsync(id);
            var result = item.Map<OrderViewModel>();
            return result;
        }

        // POST: api/Order
        /// <summary>
        /// 创建影院
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task Post(OrderCreateDto value)
        {
            ThrowIfNotModelIsValid();

            await CommandBus.SendAsync(new OrderCreateCommand { Input = value });
        }

        // PUT: api/Order/5
        /// <summary>
        /// 更新影院
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        [HttpPut("{id}")]
        public async Task Put(Guid id, OrderUpdateDto value)
        {
            ThrowIfNotModelIsValid();
            await CommandBus.SendAsync(new OrderUpdateCommand { Input = value });
        }

        // DELETE: api/Order/5
        /// <summary>
        /// 删除影院
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await CommandBus.SendAsync(new OrderDeleteCommand { Input = new ItemDeleteDto { Id = id } });
        }
    }
}
