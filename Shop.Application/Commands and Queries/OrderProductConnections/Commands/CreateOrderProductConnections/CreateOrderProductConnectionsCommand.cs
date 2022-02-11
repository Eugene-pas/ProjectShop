using MediatR;
using Shop.Application.OrderProductConnections.Queries;

namespace Shop.Application.Commands_and_Queries.OrderProductConnections.Commands.CreateOrderProductConnections
{
    public class CreateOrderProductConnectionsCommand
        : IRequest<OrderProductConnectionVm>
    {
        public long OrderId { get; set; }
        public long ProductId { get; set; }
       
    }
}
