using System.Collections.Generic;

namespace Shop.Application.Orders.Queries.GetAllOrder
{
    public class OrderVm
    {
        public IList<OrderLookupDto> Order { get; set;}
    }
}
