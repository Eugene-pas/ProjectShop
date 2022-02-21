using FluentValidation;

namespace Shop.Application.Commands.Sellers.Commands.UpdateSeller
{
    public class UpdateSellerCommandValidator
        : AbstractValidator<UpdateSellerCommand>
    {
        public UpdateSellerCommandValidator()
        {
            RuleFor(seller =>
                seller.Id).NotEmpty();
            RuleFor(seller =>
                seller.Name).NotEmpty().MaximumLength(250);
            RuleFor(seller =>
                seller.Description).NotEmpty().MaximumLength(5000);
            RuleFor(seller =>
                seller.Contact).NotEmpty().MaximumLength(13);
        }
    }
}
