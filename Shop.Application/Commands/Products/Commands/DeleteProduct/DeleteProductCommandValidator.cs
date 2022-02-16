using FluentValidation;
using Shop.Application.Commands_and_Queries.Products;
using Shop.Domain.Entities;

namespace Shop.Application.Commands.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandValidator
        : AbstractValidator<DeleteProductCommand>
    {
        private readonly ProductExistTask existTask;
        public DeleteProductCommandValidator(IDataBaseContext dbContext)
        {
            existTask = new ProductExistTask(dbContext);

            RuleFor(deleteProductCammandValidator =>
            deleteProductCammandValidator.Id).NotEmpty()
            .NotNull().WithMessage("ID is required.")
            .NotEqual(0).WithMessage("There is no field with this ID")
            .MustAsync(existTask.Exist)
            .WithMessage("The specified customerId doesn't exist");
        }
    }
}
