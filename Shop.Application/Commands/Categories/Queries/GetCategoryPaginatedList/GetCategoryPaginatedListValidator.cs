using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Commands.Orders.Commands.CreateOrder;
using Shop.Application.Interfaces;

namespace Shop.Application.Commands.Categories.Queries.GetCategoryPaginatedList
{
    public class GetCategoryPaginatedListValidator
        : AbstractValidator<GetCategoryPaginatedListQuery>
    {
        private readonly IDataBaseContext _dbContext;

        public GetCategoryPaginatedListValidator(IDataBaseContext dbContext)
        {
            _dbContext = dbContext;

            RuleFor(paginatedList =>
                    paginatedList.Page)
                .GreaterThan(-1)
                .WithMessage("Count must be > 0")
                .NotEqual(0)
                .WithMessage("The DeliveryId value must not equal to 0");

            RuleFor(paginatedList =>
                    paginatedList.PageSize)
                .NotEqual(0)
                .WithMessage("The DeliveryId value must not equal to 0")
                .GreaterThan(-1)
                .WithMessage("Count must be > 0");

        }
    }
}