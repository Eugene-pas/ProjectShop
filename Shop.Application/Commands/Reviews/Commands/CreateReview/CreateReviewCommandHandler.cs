﻿using AutoMapper;
using MediatR;
using Shop.Application.Commands.Reviews.Queries;
using Shop.Application.Common;
using Shop.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Commands.Reviews.Commands.CreateReview
{
    public class CreateReviewCommandHandler
        : HandlersBase, IRequestHandler<CreateReviewCommand, ReviewsVm>
    {
        public CreateReviewCommandHandler(IDataBaseContext dbContext, IMapper mapper)
               : base(dbContext, mapper) { }

        public async Task<ReviewsVm> Handle(CreateReviewCommand request,
                CancellationToken cancellationToken)
        {
            var review = new Review
            {
                Product = _dbContext.Product.Find(request.ProductId),
                CustomerName = request.CustomerName,
                Rating = request.Rating,
                Comments = request.Comments,
                Created = DateTime.Now,
            };

            await _dbContext.Review.AddAsync(review, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return _mapper.Map<ReviewsVm>(review);
        }
    }
}
