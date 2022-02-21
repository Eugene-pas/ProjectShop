using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Interfaces;

namespace Shop.Application.Commands.Orders.Queries.GetOrder
{
    public class GetOrderQueryValidator : AbstractValidator<GetOrderQuery>
    {
        private readonly IDataBaseContext _dbContext;
        public GetOrderQueryValidator(IDataBaseContext dataBase)
        {
            _dbContext = dataBase;
            RuleFor(Order =>
                Order.Id)
                .NotEmpty().WithMessage("ID is required.")
            .NotNull().WithMessage("ID can not be aqueal null.")
            .NotEqual(0).WithMessage("There is no field with this ID")
            .MustAsync(Exist).WithMessage("The specified orderId doesn't exist");
        }
        public async Task<bool> Exist(long orderId, CancellationToken cancellationToken)
        {
            return await _dbContext.Customer
                .AnyAsync(x => x.Id == orderId);
        }
    }
}
