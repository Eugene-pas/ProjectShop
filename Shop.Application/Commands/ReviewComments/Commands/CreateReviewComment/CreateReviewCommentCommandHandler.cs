using AutoMapper;
using MediatR;
using Shop.Application.Commands.ReviewComments.Queries;
using Shop.Application.Common;
using Shop.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Commands.ReviewComments.Commands.CreateReviewComment
{
    public class CreateReviewCommentCommandHandler
        : HandlersBase, IRequestHandler<CreateReviewCommentCommand, ReviewCommentVm>
    {
        public CreateReviewCommentCommandHandler(IDataBaseContext dbContext, IMapper mapper)
               : base(dbContext, mapper) { }

        public async Task<ReviewCommentVm> Handle(CreateReviewCommentCommand request,
                CancellationToken cancellationToken)
        {
            var comment = new ReviewComment
            {
                Review = _dbContext.Review.Find(request.ReviewId),
                Customer = _dbContext.Customer.Find(request.CustomerId),
                Comment = request.Comment,
                CreationDate = DateTime.Now,
            };

            await _dbContext.ReviewComment.AddAsync(comment, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return _mapper.Map<ReviewCommentVm>(comment);
        }
    }
}
