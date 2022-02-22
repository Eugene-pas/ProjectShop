using MediatR;
using Shop.Application.Commands.ReviewLikes.Queries;

namespace Shop.Application.Commands.ReviewLikes.Commands.DeleteReviewLike
{
    public class DeleteReviewLikeCommand : IRequest<ReviewLikeVm>
    {
        public long Id { get; set; }
    }
}
