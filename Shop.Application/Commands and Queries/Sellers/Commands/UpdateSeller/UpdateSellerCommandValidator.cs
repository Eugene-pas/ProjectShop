using FluentValidation;

namespace Shop.Application.Sellers.Commands.UpdateSeller
{
    public class UpdateSellerCommandValidator : AbstractValidator<UpdateSellerCommand>
    {
        public UpdateSellerCommandValidator()
        {
            RuleFor(Seller =>
                Seller.Id).NotEmpty();
            RuleFor(Seller =>
                Seller.Name).NotEmpty().MaximumLength(250);
            RuleFor(Seller =>
                Seller.Description).NotEmpty().MaximumLength(5000);
            RuleFor(Seller =>
                Seller.Contact).NotEmpty().MaximumLength(13);
        }
    }
}
