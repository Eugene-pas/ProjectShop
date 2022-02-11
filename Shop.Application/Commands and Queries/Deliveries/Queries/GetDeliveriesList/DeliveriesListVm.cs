using Shop.Application.Deliveries.Queries.GetDelivery;
using System.Collections.Generic;

namespace Shop.Application.Deliveries.Queries.GetDeliveriesList
{
    public class DeliveriesListVm
    {
        public IList<DeliveryVm> Deliveries { get; set; }
    }
}
