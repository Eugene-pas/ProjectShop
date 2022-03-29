using MediatR;

namespace Shop.Application.Commands.Orders.Queries.GetOrdersList
{
    public class GetOrdersListQuery 
        : IRequest<OrdersListVm>
    {
       
    }
}
