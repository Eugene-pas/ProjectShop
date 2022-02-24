using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Shop.Application.Commands.Products;
using Shop.Application.Interfaces;

namespace Shop.Application.Commands.Filters.FiltrationByRating
{
    internal class GetFiltrationByRatingValidator
        : AbstractValidator<GetFiltrationByRatingQuery>
    {
        public GetFiltrationByRatingValidator(IDataBaseContext dbContext)
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
                .WithMessage("PageSize must be > 0");

            RuleFor(paginatedList =>
                    paginatedList.PageSize)
                .NotEqual(0)
                .WithMessage("The PageSize value must not equal to 0")
                .GreaterThan(-1)
                .WithMessage("PageSize must be > 0");

            RuleFor(paginatedList =>
                    paginatedList.Rating)
                .GreaterThan(-1)
                .WithMessage("Rating must be > 0");
        }
    }
}
