using System;
using FluentValidation;

namespace Shop.Application.Sellers.Commands.DeleteSeller
{
    public class DeleteSellerCommandValidator : AbstractValidator<DeleteSellerCommand>
    {
        public DeleteSellerCommandValidator()
        {
            RuleFor(Seller =>
                Seller.Id).NotEmpty();
        }
    }
}
