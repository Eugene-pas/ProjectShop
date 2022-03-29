using Shop.Application.Commands.Orders.Queries.GetOrdersList;
using System.Collections.Generic;

namespace Shop.Application.Commands.Orders.Queries.GetOrderPaginatedListForCustomer
{
    public class OrderPaginatedListForCustomerVm
    {
        public IList<OrdersLookupDto> ListOrders { get; set; }
        public int Page { get; set; }
        public int TotalPage { get; set; }
        public bool HasPreviousPage { get; set; }
        public bool HasNextPage { get; set; }
    }
}
