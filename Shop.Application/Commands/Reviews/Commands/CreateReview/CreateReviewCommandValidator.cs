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

            RuleFor(x => x.CustomerId)
                 .NotEqual(0)
                 .WithMessage("The CustomerId value must not equal to 0")
                 .MustAsync(CustomerExist)
                 .WithMessage("The specified CustomerId doesn't exist.");

            RuleFor(x => x.ProductId)
                .NotEqual(0)
                .WithMessage("The ProductId value must not equal to 0")
                .MustAsync(ProductExist)
                .WithMessage("The specified ProductId doesn't exist.");

            RuleFor(x => x.Rating)
                .InclusiveBetween(1, 5).WithMessage("1<= rating <=5");

            RuleFor(x => x.Comment)
                .NotEmpty()
                .NotNull().WithMessage("Comment is required.");
        }

        public async Task<bool> ProductExist(long Id, CancellationToken cancellationToken)
        {
            return await _dbContext.Product.AnyAsync(x => x.Id == Id);
        }

        public async Task<bool> CustomerExist(long Id, CancellationToken cancellationToken)
        {
            return await _dbContext.Customer.AnyAsync(x => x.Id == Id);
        }
    }
}
