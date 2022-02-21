using MediatR;
using Shop.Application.Commands.Orders.Queries.GetOrdersList;

namespace Shop.Application.Commands.Orders.Queries.GetOrdersListForCustomer
{
    public class GetOrdersListForCustomerQuery
        : IRequest<OrderListVm>
    {
        public long  customerId { get; set; }
    }
}
