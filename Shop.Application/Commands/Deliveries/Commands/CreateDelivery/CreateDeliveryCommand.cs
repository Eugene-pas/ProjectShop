using System.Collections.Generic;
using MediatR;
using Shop.Application.Commands.Deliveries.Queries.GetDelivery;
using Shop.Domain.Entities;

namespace Shop.Application.Commands.Deliveries.Commands.CreateDelivery
{
    public class CreateDeliveryCommand : IRequest<DeliveryVm>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<DeliveryProductConnection> DeliveryProductConnection { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}
