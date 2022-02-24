using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Shop.Application.Interfaces;

namespace Shop.Application.Commands.Products.Queries.GetProductsListByPrice
{
    public class GetProductsListByPriceIncreaseValidator
        : AbstractValidator<GetProductsListByPriceIncreaseQuery>
    {
        public GetProductsListByPriceIncreaseValidator(IDataBaseContext dbContext)
        {
            var existTask = new ProductExistTask(dbContext);

            RuleFor(paginatedList =>
                    paginatedList.CategoryId)
                .NotEmpty().WithMessage("ID is required.")
                .NotNull().WithMessage("ID can not be equeal null.")
                .GreaterThan(0).WithMessage("ID must be greater than zero.")
                .MustAsync(existTask.CategoryExist).WithMessage("There is no field with this ID.")
                .WithMessage("The specified CategoryId doesn't exist.");

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
