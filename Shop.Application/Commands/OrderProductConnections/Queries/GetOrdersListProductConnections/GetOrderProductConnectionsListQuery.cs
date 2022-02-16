using MediatR;

namespace Shop.Application.Commands_and_Queries.OrderProductConnections.Queries.GetOrdersListProductConnections
{
    public class GetOrderProductConnectionsListQuery
        : IRequest<OrderProductConnectionListVm>
    {
    }
}
