using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Commands.ReviewComments.Queries.GetReviewCommentList;
using Shop.Application.Common;
using Shop.Domain.Entities;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Commands.ReviewComments.Queries.GetReviewCommentForReview
{
    public class GetReviewCommentForReviewQueryHandler
        : HandlersBase, IRequestHandler<GetReviewCommentForReviewQuery, ReviewCommentsVm>
    {
        public GetReviewCommentForReviewQueryHandler(IDataBaseContext dbContext, IMapper mapper)
               : base(dbContext, mapper) { }

        public async Task<ReviewCommentsVm> Handle(GetReviewCommentForReviewQuery request,
               CancellationToken cancellationToken)
        {
            var comments = await _dbContext.ReviewComment
                .Where(x => x.Review.Id == request.ReviewId)
                .ProjectTo<ReviewCommentsLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new ReviewCommentsVm
            {
                ReviewComments = comments,
                TotalComments = comments.Count
            };
        }
    }
}
