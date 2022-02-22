using MediatR;

namespace Shop.Application.Commands.OrderProductConnections.Queries.GetOrdersListProductConnections
{
    public class GetOrderProductConnectionsListQuery
        : IRequest<OrderProductConnectionListVm>
    {
    }
}
