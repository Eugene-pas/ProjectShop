using MediatR;

namespace Shop.Application.Commands.ReviewLikes.Queries.GetReviewLike
{
    public class GetReviewLikeQuery : IRequest<ReviewLikeVm>
    {
        public long Id { get; set; }
    }
}
