using Evol.Domain.Dto;
using Evol.Domain.Messaging;
using Evol.TMovie.Domain.Commands;
using Evol.TMovie.Domain.Models.AggregateRoots;
using Evol.TMovie.Domain.Models.Values;
using Evol.TMovie.Domain.QueryEntries;
using Evol.TMovie.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace Evol.TMovie.Domain.CommandHandlers
{
    public class OrderCommandHandler :
        ICommandHandler<OrderCreateCommand>,
        ICommandHandler<OrderPayCommand>,
        ICommandHandler<OrderReceiveCommand>
    {
        public IOrderRepository OrderRepository { get; set; }

        public IOrderDetailRepository OrderDetailRepository { get; set; }

        public IOrderQueryEntry OrderQueryEntry { get; set; }


        public OrderCommandHandler(IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository, IOrderQueryEntry orderQueryEntry)
        {
            OrderRepository = orderRepository;
            OrderDetailRepository = orderDetailRepository;
            OrderQueryEntry = orderQueryEntry;
        }
        public async Task ExecuteAsync(OrderCreateCommand command)
        {
            var order = command.Input.Map<Order>();
            order.Id = Guid.NewGuid();
            order.CreateTime = DateTime.Now;
            await OrderRepository.InsertAsync(order);

            var details = order.Items;
            await OrderDetailRepository.InsertRangeAsync(details);
        }

        public async Task ExecuteAsync(OrderPayCommand command)
        {
            var dto = command.Input;
            var order = await OrderQueryEntry.FindAsync(dto.OrderId, dto.UserId);
            if (order == null)
                throw new Exception("userId不匹配");
            order.PaidAmount = dto.PaidAmount;
            order.PayTime = DateTime.Now;
            order.Status = Models.Values.OrderStatusType.Paid;
            await OrderRepository.UpdateAsync(order);
        }

        public async Task ExecuteAsync(OrderReceiveCommand command)
        {
            var dto = command.Input;
            var order = await OrderQueryEntry.FindAsync(dto.OrderId, dto.UserId);
            if (order == null)
                throw new Exception("userId不匹配");
            order.Status = OrderStatusType.Received;
            order.ReceivedTime = DateTime.Now;
            await OrderRepository.UpdateAsync(order);
        }

        public async Task ExecuteAsync(OrderCompleteCommand command)
        {
            var dto = command.Input;
            var order = await OrderQueryEntry.FindAsync(dto.OrderId, dto.UserId);
            if (order == null)
                throw new Exception("userId不匹配");
            order.Status = OrderStatusType.Completed;
            order.CompletedTime = DateTime.Now;
            await OrderRepository.UpdateAsync(order);
        }

        public async Task ExecuteAsync(OrderCloseCommand command)
        {
            var dto = command.Input;
            var order = await OrderQueryEntry.FindAsync(dto.OrderId, dto.UserId);
            if (order == null)
                throw new Exception("userId不匹配");
            order.Status = OrderStatusType.Closed;
            order.ClosedTime = DateTime.Now;
            await OrderRepository.UpdateAsync(order);
        }
    }
}
