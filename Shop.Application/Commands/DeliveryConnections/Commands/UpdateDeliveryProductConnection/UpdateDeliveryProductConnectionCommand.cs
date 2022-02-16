using MediatR;
using Shop.Application.DeliveryConnections.Queries;

namespace Shop.Application.Commands_and_Queries.DeliveryConnections.Commands.UpdateDeliveryProductConnection
{
    public class UpdateDeliveryProductConnectionCommand : IRequest<DeliveryProductConnectionVm>
    {
        public long Id { get; set; }
        public long DeliveryId { get; set; }
        public long ProductId { get; set; }
    }
}
