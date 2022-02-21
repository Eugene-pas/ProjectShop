using MediatR;

namespace Shop.Application.Commands.DeliveryConnections.Queries.GetDeliveryProductConnectionsList
{
    public class GetDeliveryProductConnectionsListQuery : IRequest<DeliveryProductConnectionsListVm>
    {
        public long Id { get; set; }
    }
}
