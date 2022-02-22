using System.Collections.Generic;

namespace Shop.Application.Commands.ProductImages.Queries.GetProductImagesList
{
    public class ProductImageVm
    {
        public IList<ProductImageLookupDto> ProductImage { get; set; }
    }
}
