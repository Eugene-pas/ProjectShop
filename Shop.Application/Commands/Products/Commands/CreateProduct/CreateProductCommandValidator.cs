using FluentValidation;
using Shop.Application.Interfaces;

namespace Shop.Application.Commands.Products.Commands.CreateProduct
{
    public class CreateProductCommandValidator
        : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator(IDataBaseContext dbContext)
        {

            var existTask = new ProductExistTask(dbContext);

            RuleFor(createProductCommandValidator =>
            createProductCommandValidator.Name)
            .NotEmpty().WithMessage("Name can not be empty.")
            .NotNull().WithMessage("Name can not be equal null.");

            RuleFor(createProductCommandValidator =>
                    createProductCommandValidator.CategoryId)
            .NotEmpty().WithMessage("CategoryId can not be empty.")
            .NotNull().WithMessage("ID is required.")
            .MustAsync(existTask.CategoryExist)
            .WithMessage("The specified CategoryId doesn't exist");

            RuleFor(createProductCommandValidator =>
                    createProductCommandValidator.SellerId)
                .NotEmpty().WithMessage("SellerId can not be empty.")
                .NotNull().WithMessage("ID is required.")
                .MustAsync(existTask.SellerExist)
                .WithMessage("The specified SellerId doesn't exist");

            RuleFor(createProductCommandValidator =>
            createProductCommandValidator.Price).NotEmpty().WithMessage("Price can not be empty.")
            .NotNull().WithMessage("Price is required.")
            .GreaterThan(0).WithMessage("Price must be > 0");

            RuleFor(createProductCommandValidator =>
            createProductCommandValidator.Description).NotEmpty().WithMessage("Description can not be empty.")
            .NotNull().WithMessage("Description is required.");

            RuleFor(createProductCommandValidator =>
            createProductCommandValidator.OnStorageCount)
            .GreaterThan(-1).WithMessage("Count must be => 0");

        }
    }
}
