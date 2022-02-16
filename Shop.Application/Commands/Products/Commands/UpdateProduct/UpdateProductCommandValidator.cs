using FluentValidation;
using Shop.Application.Commands_and_Queries.Products;
using Shop.Domain.Entities;

namespace Shop.Application.Commands.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandValidator
        : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator(IDataBaseContext dbContext)
        {
            var existTask = new ProductExistTask(dbContext);

            RuleFor(deleteProductCommandValidator =>
            deleteProductCommandValidator.Id).NotEmpty()
            .NotNull().WithMessage("ID is required.")
            .NotEqual(0).WithMessage("There is no field with this ID")
            .MustAsync(existTask.Exist)
            .WithMessage("The specified customerId doesn't exist");

            RuleFor(createProductCommandValidator =>
            createProductCommandValidator.Name)
            .NotEmpty()
            .NotNull().WithMessage("Name can not be equal null.");

            RuleFor(createProductCommandValidator =>
            createProductCommandValidator.Price).NotEmpty()
            .NotNull().WithMessage("Price is required.")
            .GreaterThan(0).WithMessage("Price must be > 0");

            RuleFor(createProductCommandValidator =>
            createProductCommandValidator.Description).NotEmpty()
            .NotNull().WithMessage("Description is required.");

            RuleFor(createProductCommandValidator =>
            createProductCommandValidator.OnStorageCount)
            .GreaterThan(-1).WithMessage("Count must be => 0");

            RuleFor(createProductCommandValidator =>
            createProductCommandValidator.Rating).InclusiveBetween(1, 5)
            .WithMessage("1<= rating <=5");
        }
    }
}
