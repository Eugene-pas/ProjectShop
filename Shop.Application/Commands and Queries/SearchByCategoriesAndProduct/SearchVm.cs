using Shop.Domain.Entities;
using System.Collections.Generic;

namespace Shop.Application.Commands_and_Queries.SearchByCategoriesAndProduct
{
    public class SearchVm
    {
        public IList<Category> Categories { get; set; }

        public IList<Product> Products { get; set; }
    }
}
