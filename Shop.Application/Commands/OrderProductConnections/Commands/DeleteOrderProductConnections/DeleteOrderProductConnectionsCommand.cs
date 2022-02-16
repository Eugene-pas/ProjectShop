using MediatR;
using Shop.Application.OrderProductConnections.Queries;

namespace Shop.Application.Commands_and_Queries.OrderProductConnections.Commands.DeleteOrderProductConnections
{
    public class DeleteOrderProductConnectionsCommand
        : IRequest<OrderProductConnectionVm>
    {
        public long Id { get; set; }
    }
}
