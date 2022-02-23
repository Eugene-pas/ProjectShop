using MediatR;
using Shop.Application.Commands.ReviewLikes.Queries;

namespace Shop.Application.Commands.ReviewLikes.Commands.CreateReviewLike
{
    public class CreateReviewLikeCommand : IRequest<ReviewLikeVm>
    {
        public long ReviewId { get; set; }

        public long CustomerId { get; set; }

        public bool IsLike { get; set; }
    }
}
