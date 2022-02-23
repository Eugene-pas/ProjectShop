using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Common;
using Shop.Application.Exceptions;
using Shop.Application.Interfaces;
using Shop.Domain.Entities;

namespace Shop.Application.Commands.ReviewComments.Queries.GetReviewComment
{
    public class GetReviewCommentQueryHandler
        : HandlersBase, IRequestHandler<GetReviewCommentQuery, ReviewCommentVm>
    {
        public GetReviewCommentQueryHandler(IDataBaseContext dbContext, IMapper mapper)
               : base(dbContext, mapper) { }

        public async Task<ReviewCommentVm> Handle(GetReviewCommentQuery request, 
            CancellationToken cancellationToken)
        {
            var comment = await _dbContext.ReviewComment
                .Include(x => x.Review)
                .Include(x => x.Customer)
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            _ = comment ?? throw new NotFoundException(nameof(ReviewComment), request.Id);

            return _mapper.Map<ReviewCommentVm>(comment);
        }
    }
}
