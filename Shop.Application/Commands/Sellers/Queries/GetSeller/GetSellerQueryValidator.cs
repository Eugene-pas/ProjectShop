using FluentValidation;

namespace Shop.Application.Commands.Sellers.Queries.GetSeller
{
    public class GetSellerQueryValidator : AbstractValidator<GetSellerQuery>
    {
        public GetSellerQueryValidator()
        {
            RuleFor(Seller =>
                Seller.Id).NotEmpty();
        }
    }
}
