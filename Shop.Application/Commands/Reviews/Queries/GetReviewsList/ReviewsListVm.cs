using System.Collections.Generic;

namespace Shop.Application.Commands.Reviews.Queries.GetReviewsList
{
    public class ReviewsListVm
    {
        public IList<ReviewsLookupDto> Reviews { get; set; }
    }
}
