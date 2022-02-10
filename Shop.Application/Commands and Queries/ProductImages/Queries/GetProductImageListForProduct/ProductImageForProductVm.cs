using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Commands_and_Queries.ProductImages.Queries.GetProductImageListForProduct
{
    public class ProductImageForProductVm
    {
        public IList<ProductImageForProductLookupDto> ProductImages { get; set; }
    }
}
