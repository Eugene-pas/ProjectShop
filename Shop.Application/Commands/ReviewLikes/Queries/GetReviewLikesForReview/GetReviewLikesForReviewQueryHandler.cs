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

namespace Shop.Application.Commands.ReviewLikes.Queries.GetReviewLikesForReview
{
    public class GetReviewCommentForReviewQueryHandler
        : HandlersBase, IRequestHandler<GetReviewCommentForReviewQuery, ReviewLikesVm>
    {
        public GetReviewCommentForReviewQueryHandler(IDataBaseContext dbContext, IMapper mapper)
               : base(dbContext, mapper) { }

        public async Task<ReviewLikesVm> Handle(GetReviewCommentForReviewQuery request,
               CancellationToken cancellationToken)
        {
            var like = await _dbContext.ReviewLike
                .Where(x => x.Review.Id == request.ReviewId)
                .ProjectTo<ReviewLikesLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new ReviewLikesVm
            {
                ReviewLikes = like,
                TotalLikes = like.Where(x => x.IsLike == true).Count(),
                TotalDislike = like.Where(x => x.IsLike == false).Count()
            };
        }
    }
}
