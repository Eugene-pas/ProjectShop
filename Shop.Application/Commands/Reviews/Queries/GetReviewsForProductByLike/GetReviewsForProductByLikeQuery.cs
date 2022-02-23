using MediatR;
using Shop.Application.Commands.Reviews.Queries.GetReviewsForProduct;

namespace Shop.Application.Commands.Reviews.Queries.GetReviewsForProductByLike
{
    public class GetReviewsForProductByLikeQuery : IRequest<ReviewsForProductVm>
    {
        public long ProductId { get; set; }
    }
}
