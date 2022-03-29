using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Shop.Application.Interfaces;

namespace Shop.Application.Commands.Orders.Queries.GetOrderPaginatedList
{
    public class GetOrderPaginatedListValidator
        : AbstractValidator<GetOrderPaginatedListQuery>
    {
        private readonly IDataBaseContext _dbContext;

        public GetOrderPaginatedListValidator(IDataBaseContext dbContext)
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

            RuleFor(paginatedList =>
                    paginatedList.PageSize)
                .NotEqual(0)
                .WithMessage("The DeliveryId value must not equal to 0")
                .GreaterThan(-1)
                .WithMessage("Count must be > 0");

        }
    }
}
