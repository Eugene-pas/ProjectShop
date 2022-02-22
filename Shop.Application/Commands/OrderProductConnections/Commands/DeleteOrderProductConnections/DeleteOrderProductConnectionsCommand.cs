using MediatR;
using Shop.Application.Commands.OrderProductConnections.Queries;

namespace Shop.Application.Commands.OrderProductConnections.Commands.DeleteOrderProductConnections
{
    public class DeleteOrderProductConnectionsCommand
        : IRequest<OrderProductConnectionVm>
    {
        public long Id { get; set; }
    }
}
