using System.Collections.Generic;

namespace Shop.Application.Commands.ProductImages.Queries.GetProductImageListForProduct
{
    public class ProductImageForProductVm
    {
        public IList<ProductImageForProductLookupDto> ProductImages { get; set; }
    }
}
