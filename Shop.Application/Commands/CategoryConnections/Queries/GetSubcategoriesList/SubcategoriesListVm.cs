using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Domain.Entities;

namespace Shop.Application.Commands.CategoryConnections.Queries.GetSubcategoriesList
{
    public class SubcategoriesListVm
    {
        public IList<Category> CategoriesList { get; set; }
    }
}
