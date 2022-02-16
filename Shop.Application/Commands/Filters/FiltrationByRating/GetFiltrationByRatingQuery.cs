using MediatR;

namespace Shop.Application.Commands.Filters.FiltrationByRating
{
    public class GetFiltrationByRatingQuery : IRequest<FilteredProductsListVm>
    {
        public long CategoryId { get; set; }

        public int Rating { get; set; }
    }
}
