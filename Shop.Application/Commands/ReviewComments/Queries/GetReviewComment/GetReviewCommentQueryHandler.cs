using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Common;
using Shop.Application.Exceptions;
using Shop.Domain.Entities;

namespace Shop.Application.Commands.ReviewComments.Queries.GetReviewComment
{
    public class GetReviewCommentListQueryHandler 
        : HandlersBase, IRequestHandler<GetReviewCommentQuery, ReviewCommentVm>
    {
        public GetReviewCommentListQueryHandler(IDataBaseContext dbContext, IMapper mapper)
               : base(dbContext, mapper) { }

        public async Task<ReviewCommentVm> Handle(GetReviewCommentQuery request, 
            CancellationToken cancellationToken)
        {
            var reviewcomment = await _dbContext.ReviewComment
                .FirstOrDefaultAsync(reviewcomment =>
            reviewcomment.Id == request.Id, cancellationToken);

            _ = reviewcomment ?? throw new NotFoundException(nameof(ReviewComment), request.Id);

            return _mapper.Map<ReviewCommentVm>(reviewcomment);
        }
    }
}
