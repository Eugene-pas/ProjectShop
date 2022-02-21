using MediatR;
using Shop.Application.Commands.OrderProductConnections.Queries;

namespace Shop.Application.Commands.OrderProductConnections.Commands.UpdateOrderProductConnections
{
    public class UpdateOrderProductConnectionsCommand
        : IRequest<OrderProductConnectionVm>
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public long ProductId { get; set; }
    }
}
