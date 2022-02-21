using System.Collections.Generic;
using Shop.Domain.Entities;

namespace Shop.Application.Commands.SearchByCategoriesAndProduct
{
    public class SearchVm
    {
        public IList<Category> Categories { get; set; }

        public IList<Product> Products { get; set; }
    }
}
