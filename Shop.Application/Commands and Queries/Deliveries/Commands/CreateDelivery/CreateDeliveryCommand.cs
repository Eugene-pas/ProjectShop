using MediatR;
using Shop.Application.Commands_and_Queries.Deliveries;
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
