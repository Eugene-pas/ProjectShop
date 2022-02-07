using FluentValidation;
using Shop.Application.Products.Commands.CreateProduct;

namespace Shop.Application.Commands_and_Queries.Products.Commands.CreateProduct
{
    public class CreateProductCommandValidator
        : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(createProductCammandValidator =>
            createProductCammandValidator.Name)
            .NotEmpty()
            .NotNull().WithMessage("Name can not be equeal null.");

            RuleFor(createProductCammandValidator =>
            createProductCammandValidator.Price).NotEmpty()
            .NotNull().WithMessage("Price is required.")
            .GreaterThan(0).WithMessage("Prise must be > 0");

            RuleFor(createProductCammandValidator =>
            createProductCammandValidator.Description).NotEmpty()
            .NotNull().WithMessage("Description is required.");

            RuleFor(createProductCammandValidator =>
            createProductCammandValidator.OnStorageCount)
            .GreaterThan(-1).WithMessage("Count must be => 0");

            RuleFor(createProductCammandValidator =>
            createProductCammandValidator.Rating).InclusiveBetween(1, 5)
            .WithMessage("1<= rating <=5");
        }
    }
}
