using AutoMapper;
using MediatR;
using Shop.Application.Commands.Reviews.Queries;
using Shop.Application.Commands.Reviews.Queries.GetReviewsForProduct;
using Shop.Application.Common;
using Shop.Application.Exceptions;
using Shop.Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Commands.Reviews.Commands.DeleteReview
{
    public class DeleteReviewCommandHandler
        : HandlersBase, IRequestHandler<DeleteReviewCommand, ReviewsVm>
    {
        public DeleteReviewCommandHandler(IDataBaseContext dbContext, IMapper mapper)
            : base(dbContext, mapper) { }

        public async Task<ReviewsVm> Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
        {
            var reviews = await _dbContext.Review
                .FindAsync(new object[] { request.Id }, cancellationToken);

            _ = reviews ?? throw new NotFoundException(nameof(Review), reviews.Id);

            var reviewscomment = _dbContext.ReviewComment.Where(x => x.ReviewId == request.Id);

            _dbContext.ReviewComment.RemoveRange(reviewscomment);
            _dbContext.Review.Remove(reviews);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return _mapper.Map<ReviewsVm>(reviews);
        }
    }
}
