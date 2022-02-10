using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Commands_and_Queries.ProductImages.Queries.GetProductImageListForProduct
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
