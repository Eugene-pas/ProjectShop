using MediatR;
using Shop.Application.Orders.Queries.GetAllOrder;

namespace Shop.Application.Commands_and_Queries.Orders.Queries.GetOrdersListForCustomer
{
    public class GetOrdersListForCustomerQuery
        : IRequest<OrderListVm>
    {
        public long  customerId { get; set; }
    }
}
