using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Commands.ReviewLikes.Queries;
using Shop.Application.Common;
using Shop.Application.Exceptions;
using Shop.Domain.Entities;

namespace Shop.Application.Commands.ReviewLikes.Commands.DeleteReviewLike
{
    public class DeleteReviewLikeCommandHandler
        : HandlersBase, IRequestHandler<DeleteReviewLikeCommand, ReviewLikeVm>
    {
        public DeleteReviewLikeCommandHandler(IDataBaseContext dbContext, IMapper mapper)
            : base(dbContext, mapper) { }

        public async Task<ReviewLikeVm> Handle(DeleteReviewLikeCommand request, CancellationToken cancellationToken)
        {
            var reviewlike = await _dbContext.ReviewLike
                .Include(x => x.Review)
                .Include(x => x.Customer)
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            _ = reviewlike ?? throw new NotFoundException(nameof(ReviewLike), request.Id);

            _dbContext.ReviewLike.Remove(reviewlike);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return _mapper.Map<ReviewLikeVm>(reviewlike);
        }
    }
}
