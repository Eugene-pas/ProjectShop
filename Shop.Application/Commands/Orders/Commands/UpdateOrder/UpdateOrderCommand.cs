using System;
using MediatR;
using Shop.Application.Commands.Orders.Queries.GetOrder;

namespace Shop.Application.Commands.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommand
        : IRequest<OrderVm>
    {
        public long Id { get; set; }
        public DateTime? Date { get; set; }
        public string Adress { get; set; }
        public  long CustomerId { get; set; }
        public long DeliveryId { get; set; }
    }
}
