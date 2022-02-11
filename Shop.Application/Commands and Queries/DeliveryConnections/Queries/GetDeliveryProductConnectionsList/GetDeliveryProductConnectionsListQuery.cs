using MediatR;

namespace Shop.Application.Commands_and_Queries.DeliveryConnections.Queries.GetDeliveryProductConnectionsList
{
    public class GetDeliveryProductConnectionsListQuery : IRequest<DeliveryProductConnectionsListVm>
    {
        public long Id { get; set; }
    }
}
