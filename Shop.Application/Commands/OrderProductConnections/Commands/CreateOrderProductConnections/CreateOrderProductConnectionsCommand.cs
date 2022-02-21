using MediatR;
using Shop.Application.Commands.OrderProductConnections.Queries;

namespace Shop.Application.Commands.OrderProductConnections.Commands.CreateOrderProductConnections
{
    public class CreateOrderProductConnectionsCommand
        : IRequest<OrderProductConnectionVm>
    {
        public long OrderId { get; set; }
        public long ProductId { get; set; }
       
    }
}
