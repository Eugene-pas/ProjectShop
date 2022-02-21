using MediatR;
using Shop.Application.Commands.DeliveryConnections.Queries;

namespace Shop.Application.Commands.DeliveryConnections.Commands.CreatDeliveryProductConnection
{
    public class CreateDeliveryProductConnectionCommand
        : IRequest<DeliveryProductConnectionVm>
    {       
        public long DeliveryId { get; set; }
        public long ProductId { get; set; }
    }
}
