using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Commands_and_Queries.ProductImages.Queries
{
    public class ProductImageVm
    {
        public IList<ProductImageLookupDto> ProductImage { get; set; }
    }
}
