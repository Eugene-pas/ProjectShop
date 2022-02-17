using MediatR;

namespace Shop.Application.Commands.Reviews.Queries.GetReviewsForProduct
{
    public class GetReviewsForProductQuery : IRequest<ReviewsForProductVm>
    {
        public long ProductId { get; set; }
    }
}
