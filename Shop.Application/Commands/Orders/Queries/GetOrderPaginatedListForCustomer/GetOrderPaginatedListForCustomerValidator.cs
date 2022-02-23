using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Commands.Orders.Queries.GetOrderPaginatedListForCustomer
{
    public class GetOrderPaginatedListForCustomerValidator
        : AbstractValidator<GetOrderPaginatedListForCustomerQuery>
    {
        private readonly IDataBaseContext _dbContext;

        public GetOrderPaginatedListForCustomerValidator(IDataBaseContext dbContext)
        {
            _dbContext = dbContext;

            RuleFor(paginatedList =>
                    paginatedList.CustomerId)
                .NotEmpty().WithMessage("ID is required.")
                .NotNull().WithMessage("ID can not be aqueal null.")
                .NotEqual(0).WithMessage("There is no field with this ID")
                .MustAsync(Exist).WithMessage("The specified CustomerId doesn't exist");

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
        public async Task<bool> Exist(long customerId, CancellationToken cancellationToken)
        {
            return await _dbContext.Order.Include(x => x.Customer)
                .AnyAsync(x => x.Customer.Id == customerId);
        }
    }
}
