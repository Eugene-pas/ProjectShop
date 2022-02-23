using MediatR;
using Shop.Application.Commands.ReviewComments.Queries.GetReviewCommentList;

namespace Shop.Application.Commands.ReviewComments.Queries.GetReviewCommentForReview
{
    public class GetReviewCommentForReviewQuery : IRequest<ReviewCommentsVm>
    {
        public long ReviewId { get; set; }
    }
}