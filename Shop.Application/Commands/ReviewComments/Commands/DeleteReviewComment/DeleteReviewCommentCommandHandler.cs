using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Commands.ReviewComments.Queries;
using Shop.Application.Common;
using Shop.Application.Exceptions;
using Shop.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Commands.ReviewComments.Commands.DeleteReviewComment
{
    public class DeleteReviewCommentCommandHandler :
        HandlersBase, IRequestHandler<DeleteReviewCommentCommand, ReviewCommentVm>
    {
        public DeleteReviewCommentCommandHandler(IDataBaseContext dbContext, IMapper mapper)
             : base(dbContext, mapper) { }

        public async Task<ReviewCommentVm> Handle(DeleteReviewCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await _dbContext.ReviewComment
                .Include(x => x.Review)
                .Include(x => x.Customer)
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            _ = comment ?? throw new NotFoundException(nameof(ReviewComment), comment.Id);

            _dbContext.ReviewComment.Remove(comment);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return _mapper.Map<ReviewCommentVm>(comment);
        }
    }
}
