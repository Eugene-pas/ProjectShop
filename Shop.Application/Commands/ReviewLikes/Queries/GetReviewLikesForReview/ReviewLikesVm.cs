using System.Collections.Generic;

namespace Shop.Application.Commands.ReviewLikes.Queries.GetReviewLikesForReview
{
    public class ReviewLikesVm
    {
        public IList<ReviewLikesLookupDto> ReviewLikes { get; set; }

        public int TotalLikes { get; set; }

        public int TotalDislike { get; set; }
    }
}
