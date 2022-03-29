using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Interfaces;

namespace Shop.Application.Commands.Orders.Queries.GetOrdersListForCustomer
{
    internal class GetOrdersListForCustomerValidator
        : AbstractValidator<GetOrdersListForCustomerQuery>
    {
        private readonly IDataBaseContext _dbContext;
        public GetOrdersListForCustomerValidator(IDataBaseContext dataBase)
        {
            _dbContext = dataBase;
            RuleFor(Order =>
                Order.CustomerId)
                .NotEmpty().WithMessage("ID is required.")
            .NotNull().WithMessage("ID can not be aqueal null.")
            .NotEqual(0).WithMessage("There is no field with this ID")
            .MustAsync(Exist).WithMessage("The specified CustomerId doesn't exist");
        }
        public async Task<bool> Exist(long CustomerId, CancellationToken cancellationToken)
        {
            return await _dbContext.Order.Include(x => x.Customer)
                .AnyAsync(x => x.Customer.Id == CustomerId);
        }
    }
}
