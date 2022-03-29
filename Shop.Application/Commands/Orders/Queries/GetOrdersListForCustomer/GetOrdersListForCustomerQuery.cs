using MediatR;
using Shop.Application.Commands.Orders.Queries.GetOrdersList;

namespace Shop.Application.Commands.Orders.Queries.GetOrdersListForCustomer
{
    public class GetOrdersListForCustomerQuery
        : IRequest<OrdersListVm>
    {
        public long CustomerId { get; set; }
    }
}
