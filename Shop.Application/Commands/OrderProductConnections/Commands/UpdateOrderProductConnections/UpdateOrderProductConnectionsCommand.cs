using MediatR;
using Shop.Application.OrderProductConnections.Queries;

namespace Shop.Application.Commands_and_Queries.OrderProductConnections.Commands.UpdateOrderProductConnections
{
    public class UpdateOrderProductConnectionsCommand
        : IRequest<OrderProductConnectionVm>
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public long ProductId { get; set; }
    }
}
