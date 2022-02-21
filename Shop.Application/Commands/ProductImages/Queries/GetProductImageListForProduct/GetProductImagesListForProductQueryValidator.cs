using FluentValidation;

namespace Shop.Application.Commands.ProductImages.Queries.GetProductImageListForProduct
{
    public class GetProductImagesListForProductQueryValidator
    : AbstractValidator<GetProductImagesListForPruductQuery>
    {
        public GetProductImagesListForProductQueryValidator()
        {
            RuleFor(getForProduct =>
            getForProduct.ProductId)
            .NotEmpty().WithMessage("ID is required.")
            .NotNull().WithMessage("ID can not be equeal null.")
            .GreaterThan(0).WithMessage("ID must be greater than zero.");
        }
    }
}
