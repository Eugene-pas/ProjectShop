using MediatR;
using System;
using Shop.Application.Orders.Queries.GetOrder;

namespace Shop.Application.Orders.Commands.UpdateOrder
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
