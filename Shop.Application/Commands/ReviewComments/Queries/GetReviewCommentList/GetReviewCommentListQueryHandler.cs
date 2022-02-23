using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Common;
using Shop.Application.Interfaces;
using Shop.Domain.Entities;

namespace Shop.Application.Commands.ReviewComments.Queries.GetReviewCommentList
{
    public class GetReviewCommentListQueryHandler
        : HandlersBase, IRequestHandler<GetReviewCommentListQuery, ReviewCommentsVm>
    {
        public GetReviewCommentListQueryHandler(IDataBaseContext dbContext, IMapper mapper)
               : base(dbContext, mapper) { }

        public async Task<ReviewCommentsVm> Handle(GetReviewCommentListQuery request,
            CancellationToken cancellationToken)
        {
            var reviewcommentquery = await _dbContext.ReviewComment
                .ProjectTo<ReviewCommentsLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new ReviewCommentsVm
            {
                ReviewComments = reviewcommentquery,
                TotalComments = reviewcommentquery.Count,
            };
        }
    }
}
