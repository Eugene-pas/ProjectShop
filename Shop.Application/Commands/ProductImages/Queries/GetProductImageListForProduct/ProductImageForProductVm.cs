using System.Collections.Generic;

namespace Shop.Application.Commands_and_Queries.ProductImages.Queries.GetProductImageListForProduct
{
    public class ProductImageForProductVm
    {
        public IList<ProductImageForProductLookupDto> ProductImages { get; set; }
    }
}
