using System;
using System.Collections.Generic;
using MediatR;
using Shop.Application.Commands.Orders.Queries.GetOrder;
using Shop.Domain.Entities;

namespace Shop.Application.Commands.Orders.Commands.CreateOrder
{
    public class CreateOrderCommand
        : IRequest<OrderVm>
    {
        public long Id { get; set; }
        public DateTime? Date { get; set; }
        public string Adress { get; set; }
        public long CustomerId { get; set; }
        public long DeliveryId { get; set; }
        
        public virtual ICollection<OrderProductConnection> OrderProductConnection { get; set; }
    }
}
