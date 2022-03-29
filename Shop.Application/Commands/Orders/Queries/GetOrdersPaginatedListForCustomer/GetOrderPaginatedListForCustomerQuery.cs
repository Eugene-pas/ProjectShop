using MediatR;

namespace Shop.Application.Commands.Orders.Queries.GetOrderPaginatedListForCustomer
{
    public class GetOrderPaginatedListForCustomerQuery
        : IRequest<OrderPaginatedListForCustomerVm>
    {
        public long  CustomerId { get; set; }

        public int Page { get; set; }

        public int PageSize { get; set; }
    }
}
