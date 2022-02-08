using Shop.Application.Commands_and_Queries.Deliveries;
using Shop.Application.Deliveries.Queries.GetDelivery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Deliveries.Queries.GetDeliveriesList
{
    public class DeliveriesListVm
    {
        public IList<DeliveryVm> Deliveries { get; set; }
    }
}
