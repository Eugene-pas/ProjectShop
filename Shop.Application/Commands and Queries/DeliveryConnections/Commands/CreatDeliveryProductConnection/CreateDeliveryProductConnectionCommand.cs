using MediatR;
using Shop.Application.DeliveryConnections.Queries;

namespace Shop.Application.Commands_and_Queries.DeliveryConnections
{
    public class CreateDeliveryProductConnectionCommand
        : IRequest<DeliveryProductConnectionVm>
    {       
        public long DeliveryId { get; set; }
        public long ProductId { get; set; }
    }
}
