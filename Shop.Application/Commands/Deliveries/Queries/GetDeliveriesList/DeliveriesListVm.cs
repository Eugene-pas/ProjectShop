using System.Collections.Generic;
using Shop.Application.Commands.Deliveries.Queries.GetDelivery;

namespace Shop.Application.Commands.Deliveries.Queries.GetDeliveriesList
{
    public class DeliveriesListVm
    {
        public IList<DeliveryVm> Deliveries { get; set; }
    }
}
