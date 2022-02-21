using System.Collections.Generic;

namespace Shop.Application.Commands.Orders.Queries.GetOrdersList
{
    public class OrderListVm
    {
        public IList<OrderLookupDto> Order { get; set;}
    }
}
