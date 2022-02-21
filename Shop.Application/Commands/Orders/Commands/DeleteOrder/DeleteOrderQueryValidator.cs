using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Interfaces;

namespace Shop.Application.Commands.Orders.Commands.DeleteOrder
{
    public class DeleteOredrQueryValidator
   : AbstractValidator<DeleteOrderCommand>
    {
        private readonly IDataBaseContext _dbContext;
        public DeleteOredrQueryValidator(IDataBaseContext dbContext)
        {
            _dbContext = dbContext;
            RuleFor(deleteOredrQuery =>
            deleteOredrQuery.Id).NotEmpty().NotEqual(0)
                .WithMessage("The CategoryId value must not equal to 0")
                .MustAsync(Exist)
                .WithMessage("The specified OredrId doesn't exist.");

        }
        public async Task<bool> Exist(long OredrId, CancellationToken cancellationToken)
        {
            return await _dbContext.Order
                .AnyAsync(c => c.Id == OredrId);
        }
    }
}
