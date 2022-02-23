using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Commands.ReviewLikes.Queries;
using Shop.Application.Common;
using Shop.Application.Exceptions;
using Shop.Domain.Entities;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Shop.Application.Interfaces;


namespace Shop.Application.Commands.ReviewLikes.Commands.CreateReviewLike
{
    public class CreateReviewLikeCommandHandler
          : HandlersBase, IRequestHandler<CreateReviewLikeCommand, ReviewLikeVm>
    {
        public CreateReviewLikeCommandHandler(IDataBaseContext dbContext, IMapper mapper)
               : base(dbContext, mapper) { }

        public async Task<ReviewLikeVm> Handle(CreateReviewLikeCommand request,
                CancellationToken cancellationToken)
        {
            var like = new ReviewLike();
            if (!_dbContext.ReviewLike.Any(x => x.Customer.Id == request.CustomerId
                                              && x.Review.Id == request.ReviewId))
            {
                like = new ReviewLike
                {
                    Review = _dbContext.Review.Find(request.ReviewId),
                    Customer = _dbContext.Customer.Find(request.CustomerId),
                    IsLike = request.IsLike,
                };
                await _dbContext.ReviewLike.AddAsync(like, cancellationToken);
            }
            else if (_dbContext.ReviewLike.Any(x => x.Customer.Id == request.CustomerId 
                                                   && x.Review.Id == request.ReviewId))
            {
                if(_dbContext.ReviewLike.Any(x => x.IsLike != request.IsLike))
                {
                    like = _dbContext.ReviewLike
                        .Include(x => x.Customer)
                        .Include(x => x.Review)
                        .FirstOrDefault(x => x.Customer.Id == request.CustomerId 
                                            && x.Review.Id == request.ReviewId);
                    like.IsLike = request.IsLike;
                }
                else if (_dbContext.ReviewLike.Any(x => x.IsLike == request.IsLike))
                {
                    throw new LikeExistException();
                }
            }
            await _dbContext.SaveChangesAsync(cancellationToken);
            return _mapper.Map<ReviewLikeVm>(like);
        }
    }
}
