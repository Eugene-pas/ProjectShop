using MediatR;

namespace Shop.Application.Commands_and_Queries.OrderProductConnections.Commands.CreateOrderProductConnections
{
    public class CreateOrderProductConnectionsCommand
        : IRequest<long>
    {
        public long OrderId { get; set; }
        public long ProductId { get; set; }
       
    }
}
