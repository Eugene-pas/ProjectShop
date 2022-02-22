using FluentValidation;
using Shop.Application.Interfaces;

namespace Shop.Application.Commands.Products.Queries.GetProduct
{
    internal class GetProductQueryValidator
        : AbstractValidator<GetProductQuery>
    {
        public GetProductQueryValidator(IDataBaseContext dbContext)
        {
            var existTask = new ProductExistTask(dbContext);

            RuleFor(getProductQueryValidator =>
            getProductQueryValidator.Id).NotEmpty()
            .NotNull().WithMessage("ID is required.")
            .WithMessage("The specified customerId doesn't exist")
            .MustAsync(existTask.Exist);
        }
    }
}
