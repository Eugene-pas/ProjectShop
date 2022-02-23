using System.Collections.Generic;

namespace Shop.Application.Commands.Reviews.Queries.GetReviewsForProduct
{
    public class ReviewsForProductVm
    {
        public IList<ReviewsForProductLookupDto> Reviews { get; set; }

        public double TotalRating { get; set; }

        public int TotalReviews { get; set; }
    }
}
