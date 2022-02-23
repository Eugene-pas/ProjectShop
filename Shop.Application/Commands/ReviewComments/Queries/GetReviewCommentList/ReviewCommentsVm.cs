using System.Collections.Generic;

namespace Shop.Application.Commands.ReviewComments.Queries.GetReviewCommentList
{
    public class ReviewCommentsVm
    {
        public IList<ReviewCommentsLookupDto> ReviewComments { get; set; }

        public int TotalComments { get; set; }
    }
}
