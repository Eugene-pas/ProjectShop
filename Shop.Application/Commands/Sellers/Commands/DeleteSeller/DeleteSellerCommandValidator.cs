using FluentValidation;

namespace Shop.Application.Commands.Sellers.Commands.DeleteSeller
{
    public class DeleteSellerCommandValidator : AbstractValidator<DeleteSellerCommand>
    {
        public DeleteSellerCommandValidator()
        {
            RuleFor(seller =>
                seller.Id).NotEmpty();
        }
    }
}
