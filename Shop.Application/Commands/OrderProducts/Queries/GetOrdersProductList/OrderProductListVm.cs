using System.Collections.Generic;

namespace Shop.Application.Commands.OrderProducts.Queries.GetOrdersProductList
{
    public class OrderProductListVm
    {
        public IList<OrderProductLookupDto> OrderProduct { get; set; }
    }
}
