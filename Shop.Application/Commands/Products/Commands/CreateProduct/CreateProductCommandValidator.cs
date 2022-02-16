using FluentValidation;

namespace Shop.Application.Commands.Products.Commands.CreateProduct
{
    public class CreateProductCommandValidator
        : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
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
