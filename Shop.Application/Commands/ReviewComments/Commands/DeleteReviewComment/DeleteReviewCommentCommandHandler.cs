using AutoMapper;
using MediatR;
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
            var reviewcomment = await _dbContext.ReviewComment
                .FindAsync(new object[] { request.Id }, cancellationToken);

            _ = reviewcomment ?? throw new NotFoundException(nameof(ReviewComment), reviewcomment.Id);

            _dbContext.ReviewComment.Remove(reviewcomment);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return _mapper.Map<ReviewCommentVm>(reviewcomment);
        }
    }
}
