using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Common;
using Shop.Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Commands.Reviews.Queries.GetReviewsForProduct
{
    public class GetReviewsForProductQueryHandler
        : HandlersBase, IRequestHandler<GetReviewsForProductQuery, ReviewsForProductVm>
    {
        public GetReviewsForProductQueryHandler(IDataBaseContext dbContext, IMapper mapper)
               : base(dbContext, mapper) { }

        public async Task<ReviewsForProductVm> Handle(GetReviewsForProductQuery request,
               CancellationToken cancellationToken)
        {
            var reviewsforproductquery = await _dbContext.Review
                .Where(review => review.Product.Id == request.ProductId)
                .ProjectTo<ReviewsForProductLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var totalreviews = reviewsforproductquery.Count();

            return new ReviewsForProductVm { Reviews = reviewsforproductquery, TotalReviews = totalreviews };
        }
    }
}
