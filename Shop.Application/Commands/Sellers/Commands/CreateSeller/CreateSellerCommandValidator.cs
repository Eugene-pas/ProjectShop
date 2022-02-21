using FluentValidation;

namespace Shop.Application.Commands.Sellers.Commands.CreateSeller
{
    public class CreateSellerCommandValidator : AbstractValidator<CreateSellerCommand>
    {
        public CreateSellerCommandValidator()
        {
            RuleFor(Seller =>
                Seller.Name).NotEmpty().MaximumLength(250);
            RuleFor(Seller =>
                Seller.Description).NotEmpty().MaximumLength(5000);
            RuleFor(Seller =>
                Seller.Contact).NotEmpty().MaximumLength(13);
        }
    }
}
