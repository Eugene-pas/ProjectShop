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
            getProductQueryValidator.Id)
                .NotEmpty().WithMessage("ID is required.")
                .NotNull().WithMessage("ID can not be equeal null.")
                .GreaterThan(0).WithMessage("ID must be greater than zero.")
                .MustAsync(existTask.Exist).WithMessage("There is no field with this ID.")
                .WithMessage("The specified ReviewLikeId doesn't exist.");
        }
    }
}
