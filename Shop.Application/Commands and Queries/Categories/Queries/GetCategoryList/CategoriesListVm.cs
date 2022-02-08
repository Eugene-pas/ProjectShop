using Shop.Application.Categories.Commands.Queries.GetCategory;
using System.Collections.Generic;

namespace Shop.Application.Categories.Queries.GetCatagoryList
{
    public class CategoriesListVm
    {
        public IList<CategoryVm> Categories { get; set; }
    }
}