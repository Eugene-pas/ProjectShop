using System.Collections.Generic;

namespace Shop.Application.Commands.DeliveryConnections.Queries.GetDeliveryProductConnectionsList
{
    public class DeliveryProductConnectionsListVm
    {
        public IList<DeliveryProductConnectionsDto> ProductConnections { get; set; }
    }
}
