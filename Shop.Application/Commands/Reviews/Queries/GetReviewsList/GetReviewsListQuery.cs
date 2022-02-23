using MediatR;

namespace Shop.Application.Commands.Reviews.Queries.GetReviewsList
{
    public class GetReviewsListQuery : IRequest<ReviewsListVm>
    {
    }
}
