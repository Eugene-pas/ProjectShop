using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Shop.Application.Interfaces;

namespace Shop.Application.Commands.Products.Queries.GetProductsListPaginated
{
    internal class GetProductsListPaginatedValidator
        : AbstractValidator<GetProductsListPaginatedQuery>
    {
        public GetProductsListPaginatedValidator()
        {
            RuleFor(paginatedList =>
                    paginatedList.PageSize)
                .NotEqual(0)
                .WithMessage("The PageSize value must not equal to 0")
                .GreaterThan(-1)
                .WithMessage("Count must be > 0");

            RuleFor(paginatedList =>
                    paginatedList.PageSize)
                .NotEqual(0)
                .WithMessage("The PageSize value must not equal to 0")
                .GreaterThan(-1)
                .WithMessage("Count must be > 0");

        }
    }
}
