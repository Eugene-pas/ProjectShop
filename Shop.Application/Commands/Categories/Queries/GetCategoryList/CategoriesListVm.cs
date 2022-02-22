using System.Collections.Generic;
using Shop.Application.Commands.Categories.Queries.GetCategory;

namespace Shop.Application.Commands.Categories.Queries.GetCategoryList
{
    public class CategoriesListVm
    {
        public IList<CategoryVm> Categories { get; set; }
    }
}