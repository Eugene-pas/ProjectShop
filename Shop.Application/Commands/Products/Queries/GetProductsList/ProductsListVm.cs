using System.Collections.Generic;

namespace Shop.Application.Commands.Products.Queries.GetProductsList
{
    public class ProductsListVm
    {
        public IList<ProductsLookupDto> Products { get; set; }
    }
}
