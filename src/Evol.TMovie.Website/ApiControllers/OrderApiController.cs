using Evol.Common;
using Evol.Domain.Messaging;
using Evol.TMovie.Domain.QueryEntries;
using Evol.TMovie.Domain.QueryEntries.Parameters;
using Evol.TMovie.Website.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Evol.Domain.Dto;
using Evol.TMovie.Domain.Commands.Dto;
using Evol.TMovie.Domain.Commands;

namespace Evol.TMovie.Website.ApiControllers
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


        // GET: api/Order/Paged
        /// <summary>
        /// 分页查询订单
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
        /// 获取指定订单
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
        /// 创建订单
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
        /// 订单支付
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPut("Pay/{id}")]
        public async Task PutPay(Guid id, OrderPayDto value)
        {
            ThrowIfNotModelIsValid();
            await CommandBus.SendAsync(new OrderPayCommand { Input = value });
        }


        // PUT: api/Order/Receive/5
        /// <summary>
        /// 订单接收
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPut("Receive/{id}")]
        public async Task PutReceive(Guid id, OrderReceiveDto value)
        {
            ThrowIfNotModelIsValid();
            await CommandBus.SendAsync(new OrderReceiveCommand { Input = value });
        }

        // PUT: api/Order/Complete/5
        /// <summary>
        /// 完成订单
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPut("Complete/{id}")]
        public async Task PutComplete(Guid id, OrderCompleteDto value)
        {
            ThrowIfNotModelIsValid();
            await CommandBus.SendAsync(new OrderCompleteCommand { Input = value });
        }

        // PUT: api/Order/Close/5
        /// <summary>
        /// 关闭订单
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPut("Close/{id}")]
        public async Task PutClose(Guid id, OrderCloseDto value)
        {
            ThrowIfNotModelIsValid();
            await CommandBus.SendAsync(new OrderCloseCommand { Input = value });
        }

    }
}
