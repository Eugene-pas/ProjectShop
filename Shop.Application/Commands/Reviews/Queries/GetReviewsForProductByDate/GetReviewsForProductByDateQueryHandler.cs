﻿using AutoMapper;
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

namespace Shop.Application.Commands.Reviews.Queries.GetReviewsForProductByDate
{
    public class GetReviewsForProductByDateQueryHandler
        : HandlersBase, IRequestHandler<GetReviewsForProductByDateQuery, ReviewsForProductVm>
    {
        public GetReviewsForProductByDateQueryHandler(IDataBaseContext dbContext, IMapper mapper)
               : base(dbContext, mapper) { }

        public async Task<ReviewsForProductVm> Handle(GetReviewsForProductByDateQuery request,
               CancellationToken cancellationToken)
        {
            var reviews = await _dbContext.Review
                .Where(x => x.Product.Id == request.ProductId)
                .OrderByDescending(x => x.CreationDate)
                .ProjectTo<ReviewsForProductLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new ReviewsForProductVm
            {
                Reviews = reviews,
                TotalRating = Math.Round((double)reviews
                                  .Sum(x => x.Rating) / reviews.Count, 1),
                TotalReviews = reviews.Count
            };
        }
    }
}
