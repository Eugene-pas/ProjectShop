using FluentValidation;
using Shop.Domain.Entities;
using Shop.Application.Products.Queries.GetProduct;

namespace Shop.Application.Commands_and_Queries.Products.Queries.GetProdutct
{
    internal class GetProductQueryValidator
        : AbstractValidator<GetProductQuery>
    {
        readonly ProductExistTask existTask;
        public GetProductQueryValidator(IDataBaseContext dbContext)
        {
            existTask = new ProductExistTask(dbContext);

            RuleFor(getProductQueryValidator =>
            getProductQueryValidator.Id).NotEmpty()
            .NotNull().WithMessage("ID is required.")
            .WithMessage("The specified customerId doesn't exist")
            .MustAsync(existTask.Exist);
        }
    }
}
