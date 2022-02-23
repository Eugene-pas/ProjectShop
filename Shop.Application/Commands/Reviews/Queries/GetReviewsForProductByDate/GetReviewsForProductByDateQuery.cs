using MediatR;
using Shop.Application.Commands.Reviews.Queries.GetReviewsForProduct;

namespace Shop.Application.Commands.Reviews.Queries.GetReviewsForProductByDate
{
    public class GetReviewsForProductByDateQuery : IRequest<ReviewsForProductVm>
    {
        public long ProductId { get; set; }
    }
}
