using MediatR;
using Shop.Application.Deliveries.Queries.GetDelivery;
using Shop.Domain.Entities;
using System.Collections.Generic;

namespace Shop.Application.Deliveries.Commands.CreateDelivery
{
    public class CreateDeliveryCommand : IRequest<DeliveryVm>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<DeliveryProductConnection> DeliveryProductConnection { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}
