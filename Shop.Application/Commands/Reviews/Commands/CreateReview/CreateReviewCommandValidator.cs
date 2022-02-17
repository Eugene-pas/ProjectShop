using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Commands.Reviews.Commands.CreateReview
{
    public class CreateReviewCommandValidator
        : AbstractValidator<CreateReviewCommand>
    {
        private readonly IDataBaseContext _dbContext;

        public CreateReviewCommandValidator(IDataBaseContext dbContext)
        {
            _dbContext = dbContext;

            RuleFor(createreviewcommandvalidator =>
                createreviewcommandvalidator.CustomerName)
                .NotEmpty()
                .NotNull().WithMessage("Name can not be equal null.");

            RuleFor(createreviewcommandvalidator =>
                createreviewcommandvalidator.Rating)
                .InclusiveBetween(1, 5).WithMessage("1<= rating <=5");

            RuleFor(createreviewcommandvalidator =>
                createreviewcommandvalidator.Comments)
                .NotEmpty()
                .NotNull().WithMessage("Comment is required.");

            RuleFor(createreviewcommandvalidator =>
                 createreviewcommandvalidator.ProductId)
                 .NotEqual(0)
                 .WithMessage("The ProductId value must not equal to 0")
                 .MustAsync(ProductExist)
                 .WithMessage("The specified ProductId doesn't exist.");
        }

        public async Task<bool> ProductExist(long ProductId, CancellationToken cancellationToken)
        {
            return await _dbContext.Product.AnyAsync(c => c.Id == ProductId);
        }
    }
}
