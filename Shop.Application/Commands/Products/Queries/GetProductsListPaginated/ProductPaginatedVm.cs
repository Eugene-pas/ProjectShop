using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Application.Commands.Products.Queries.GetProductsList;
using Shop.Domain.Entities;

namespace Shop.Application.Commands.Products.Queries.GetProductsListPaginated
{
    public class ProductPaginatedVm
    {
        public IList<Product> Products { get; set; }
        public int Page { get; set; }
        public int TotalPagesAmount { get; set; }
        public bool HasNextPage { get; set; }
        public bool HasPreviousPage { get; set; }
    }
}
