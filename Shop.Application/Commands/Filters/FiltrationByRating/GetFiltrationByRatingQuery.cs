using MediatR;
using Shop.Application.Commands.Products.Queries.GetProductsListPaginated;

namespace Shop.Application.Commands.Filters.FiltrationByRating
{
    public class GetFiltrationByRatingQuery : IRequest<FiltrationByRatingVm>
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }
        
        public long CategoryId { get; set; }

        public double Rating { get; set; }
    }
}
