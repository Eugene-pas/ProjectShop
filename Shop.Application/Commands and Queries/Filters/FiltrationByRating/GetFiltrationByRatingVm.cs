using Shop.Domain.Entities;
using System.Collections.Generic;

namespace Shop.Application.Commands_and_Queries.Filters.FiltrationByRating
{
    public class GetFiltrationByRatingVm
    {
        public IList<Product> Products { get; set; }
    }
}
