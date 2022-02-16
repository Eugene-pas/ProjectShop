using MediatR;
using Shop.Application.Commands_and_Queries.Filters.FiltrationByRating;

namespace Shop.Application.Commands_and_Queries.Filters
{
    public class GetFiltrationByRatingQuery : IRequest<GetFiltrationByRatingVm>
    {
        public long CategoryId { get; set; }

        public int Rating { get; set; }
    }
}
