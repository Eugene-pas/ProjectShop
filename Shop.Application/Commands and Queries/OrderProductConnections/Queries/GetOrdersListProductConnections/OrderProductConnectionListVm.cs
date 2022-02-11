using System.Collections.Generic;

namespace Shop.Application.Commands_and_Queries.OrderProductConnections.Queries.GetOrdersListProductConnections
{
    public class OrderProductConnectionListVm
    {
        public IList<OrderProductConnectionLookupDto> OrderProductConnection { get; set; }
    }
}
