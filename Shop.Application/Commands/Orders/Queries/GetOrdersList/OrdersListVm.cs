using System.Collections.Generic;

namespace Shop.Application.Commands.Orders.Queries.GetOrdersList
{
    public class OrdersListVm
    {
        public IList<OrdersLookupDto> Order { get; set; }
    }
}
