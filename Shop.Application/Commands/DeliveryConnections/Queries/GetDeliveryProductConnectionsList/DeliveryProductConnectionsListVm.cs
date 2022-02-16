using System.Collections.Generic;

namespace Shop.Application.Commands_and_Queries.DeliveryConnections.Queries.GetDeliveryProductConnectionsList
{
    public class DeliveryProductConnectionsListVm
    {
        public IList<DeliveryProductConnectionsDto> ProductConnections { get; set; }
    }
}
