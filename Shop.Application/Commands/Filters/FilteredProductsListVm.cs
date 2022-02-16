using System.Collections.Generic;
using Shop.Domain.Entities;

namespace Shop.Application.Commands.Filters
{
    public class FilteredProductsListVm
    {
        public IList<Product> Products { get; set; }
    }
}
