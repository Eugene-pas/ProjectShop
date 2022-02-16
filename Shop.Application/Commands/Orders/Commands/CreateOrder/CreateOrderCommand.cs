using MediatR;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using Shop.Application.Orders.Queries.GetOrder;

namespace Shop.Application.Orders.Commands.CreateOrder
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
