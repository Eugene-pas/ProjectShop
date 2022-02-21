using MediatR;
using Shop.Application.Commands.DeliveryConnections.Queries;

namespace Shop.Application.Commands.DeliveryConnections.Commands.UpdateDeliveryProductConnection
{
    public class UpdateDeliveryProductConnectionCommand : IRequest<DeliveryProductConnectionVm>
    {
        public long Id { get; set; }
        public long DeliveryId { get; set; }
        public long ProductId { get; set; }
    }
}
