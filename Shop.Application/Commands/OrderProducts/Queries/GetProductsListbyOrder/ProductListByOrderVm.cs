using Shop.Application.Commands.OrderProducts.Queries.GetOrdersProductList;
using System.Collections.Generic;

namespace Shop.Application.Commands.OrderProducts.Queries.GetProductsListbyOrder
{
    public class ProductListByOrderVm
    {
        public IList<OrderProductLookupDto> OrderProduct { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
