using System.Collections.Generic;

namespace Shop.Application.Commands.OrderProductConnections.Queries.GetProductsListbyOrder
{
    public class GetProductListOrderVm
    {
        public IList<GetProductListOrderLookupDto> OrderProductConnection { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
