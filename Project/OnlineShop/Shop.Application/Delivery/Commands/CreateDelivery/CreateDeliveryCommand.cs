using MediatR;
using Shop.Domain.Entities;
using System.Collections.Generic;

namespace Shop.Application.Deliveries.Commands.CreateDelivery
{
    public class CreateDeliveryCommand : IRequest<long>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<DeliveryProductConnection> DeliveryProductConnection { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}
