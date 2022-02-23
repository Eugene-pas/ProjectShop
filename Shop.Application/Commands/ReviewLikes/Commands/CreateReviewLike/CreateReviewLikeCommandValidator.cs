using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Commands.ReviewLikes.Commands.CreateReviewLike
{
    public class CreateReviewLikeCommandValidator
        : AbstractValidator<CreateReviewLikeCommand>
    {
        private readonly IDataBaseContext _dbContext;

        public CreateReviewLikeCommandValidator(IDataBaseContext dbContext)
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

            RuleFor(x => x.IsLike)
                .NotNull().WithMessage("IsLike is required.");
        }

        public async Task<bool> CustomerExist(long Id, CancellationToken cancellationToken)
        {
            return await _dbContext.Customer.AnyAsync(x => x.Id == Id);
        }

        public async Task<bool> ReviewExist(long Id, CancellationToken cancellationToken)
        {
            return await _dbContext.Review.AnyAsync(x => x.Id == Id);
        }
    }
}
