using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using Shop.Application.Interfaces;

namespace Shop.Application.Commands.ReviewComments.Commands.CreateReviewComment
{
    public class CreateReviewCommentCommandValidator
        : AbstractValidator<CreateReviewCommentCommand>
    {
        private readonly IDataBaseContext _dbContext;

        public CreateReviewCommentCommandValidator(IDataBaseContext dbContext)
        {
            _dbContext = dbContext;

            RuleFor(x => x.CustomerId)
                 .NotEqual(0)
                 .WithMessage("The CustomerId value must not equal to 0")
                 .MustAsync(CustomerExist)
                 .WithMessage("The specified CustomerId doesn't exist.");

            RuleFor(x => x.ReviewId)
                .NotEqual(0)
                .WithMessage("The ReviewId value must not equal to 0")
                .MustAsync(ReviewExist)
                .WithMessage("The specified ReviewId doesn't exist.");

            RuleFor(x => x.Comment)
                .NotEmpty()
                .NotNull().WithMessage("Comment is required.");
        }

        public async Task<bool> ReviewExist(long Id, CancellationToken cancellationToken)
        {
            return await _dbContext.Review.AnyAsync(c => c.Id == Id);
        }

        public async Task<bool> CustomerExist(long Id, CancellationToken cancellationToken)
        {
            return await _dbContext.Customer.AnyAsync(c => c.Id == Id);
        }
    }
}
