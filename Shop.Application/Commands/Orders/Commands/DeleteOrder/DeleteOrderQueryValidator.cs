using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Interfaces;

namespace Shop.Application.Commands.Orders.Commands.DeleteOrder
{
    public class DeleteOrderQueryValidator
   : AbstractValidator<DeleteOrderCommand>
    {
        private readonly IDataBaseContext _dbContext;
        public DeleteOrderQueryValidator(IDataBaseContext dbContext)
        {
            _dbContext = dbContext;
            RuleFor(deleteOrderQuery =>
            deleteOrderQuery.Id).NotEmpty().NotEqual(0)
                .WithMessage("The CategoryId value must not equal to 0")
                .MustAsync(Exist)
                .WithMessage("The specified OrderId doesn't exist.");

        }
        public async Task<bool> Exist(long orderId, CancellationToken cancellationToken)
        {
            return await _dbContext.Order
                .AnyAsync(c => c.Id == orderId, cancellationToken);
        }
    }
}
