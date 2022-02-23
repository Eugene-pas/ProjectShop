using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Common;
using Shop.Domain.Entities;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Shop.Application.Interfaces;

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
            var reviews = await _dbContext.Review
                .Where(x => x.Product.Id == request.ProductId)
                .ProjectTo<ReviewsForProductLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new ReviewsForProductVm
            {
                Reviews = reviews,
                TotalRating = Math.Round((double)reviews
                                  .Sum(x => x.Rating) / reviews.Count, 1),
                TotalReviews = reviews.Count,
                
            };
        }
    }
}
