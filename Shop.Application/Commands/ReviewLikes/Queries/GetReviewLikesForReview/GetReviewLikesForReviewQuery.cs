using MediatR;

namespace Shop.Application.Commands.ReviewLikes.Queries.GetReviewLikesForReview
{
    public class GetReviewCommentForReviewQuery : IRequest<ReviewLikesVm>
    {
        public long ReviewId { get; set; }
    }
}