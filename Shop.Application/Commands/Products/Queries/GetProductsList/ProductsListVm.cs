using System.Collections.Generic;
using Shop.Domain.Entities;

namespace Shop.Application.Commands.Products.Queries.GetProductsList
{
    public class ProductsListVm
    {
        public IList<Product> Products { get; set; }
    }
}
