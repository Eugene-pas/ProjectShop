using FluentValidation;

namespace Shop.Application.Commands.Sellers.Commands.CreateSeller
{
    public class CreateSellerCommandValidator
        : AbstractValidator<CreateSellerCommand>
    {
        public CreateSellerCommandValidator()
        {
            RuleFor(seller =>
                seller.Name).NotEmpty().MaximumLength(250);
            RuleFor(seller =>
                seller.Description).NotEmpty().MaximumLength(5000);
            RuleFor(seller =>
                seller.Contact).NotEmpty().MaximumLength(13);
        }
    }
}
