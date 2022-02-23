using MediatR;

namespace Shop.Application.Commands.ReviewComments.Queries.GetReviewComment
{
    public class GetReviewCommentQuery : IRequest<ReviewCommentVm>
    {
        public long Id { get; set; }
    }
}
