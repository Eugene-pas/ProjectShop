using Shop.Domain.Entities;
using System.Collections.Generic;

namespace Shop.Application.Commands.CategoryConnections.Queries.GetSubcategoriesList
{
    public class SubcategoriesListVm
    {
        public IList<Category> CategoriesList { get; set; }
    }
}
