using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Commands.Reviews.Commands.DeleteReview
{
    public class DeleteReviewCommandValidator
        : AbstractValidator<DeleteReviewCommand>
    {
        private readonly IDataBaseContext _dbContext;

        public DeleteReviewCommandValidator(IDataBaseContext dbContext)
        {
            _dbContext = dbContext;

            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("ID is required.")
                .NotNull().WithMessage("ID can not be equeal null.")
                .GreaterThan(0).WithMessage("ID must be greater than zero.")
                .MustAsync(ReviewExist).WithMessage("There is no field with this ID.")
                .WithMessage("The specified customerId doesn't exist.");
        }

        public async Task<bool> ReviewExist(long Id, CancellationToken cancellationToken)
        {
            return await _dbContext.Review.AnyAsync(x => x.Id == Id);
        }
    }
}
