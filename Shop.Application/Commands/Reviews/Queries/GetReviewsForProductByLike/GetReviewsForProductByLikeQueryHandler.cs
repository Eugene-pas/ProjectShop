using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Commands.Reviews.Queries.GetReviewsForProduct;
using Shop.Application.Common;
using Shop.Domain.Entities;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Commands.Reviews.Queries.GetReviewsForProductByLike
{
    public class GetReviewsForProductByLikeQueryHandler
        : HandlersBase, IRequestHandler<GetReviewsForProductByLikeQuery, ReviewsForProductVm>
    {
        public GetReviewsForProductByLikeQueryHandler(IDataBaseContext dbContext, IMapper mapper)
               : base(dbContext, mapper) { }

        public async Task<ReviewsForProductVm> Handle(GetReviewsForProductByLikeQuery request,
               CancellationToken cancellationToken)
        {
            var reviewsforproductquery = await _dbContext.Review
                .Where(review => review.Product.Id == request.ProductId)
                .OrderByDescending(x => x.CreationDate)
                .ProjectTo<ReviewsForProductLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var totalreviews = reviewsforproductquery.Count;

            double totalrating = Math.Round((double)reviewsforproductquery
                .Sum(x => x.Rating) / totalreviews, 1);

            return new ReviewsForProductVm
            {
                Reviews = reviewsforproductquery,
                TotalRating = totalrating,
                TotalReviews = totalreviews
            };
        }
    }
}
