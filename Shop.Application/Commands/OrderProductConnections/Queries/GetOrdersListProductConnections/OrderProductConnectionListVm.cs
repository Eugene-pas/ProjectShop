using System.Collections.Generic;

namespace Shop.Application.Commands.OrderProductConnections.Queries.GetOrdersListProductConnections
{
    public class OrderProductConnectionListVm
    {
        public IList<OrderProductConnectionLookupDto> OrderProductConnection { get; set; }
    }
}
