using MediatR;

namespace Shop.Application.Commands_and_Queries.OrderProductConnections.Commands.DeleteOrderProductConnections
{
    public class DeleteOrderProductConnectionsCommand
        : IRequest<Unit>
    {
        public long Id { get; set; }
    }
}
