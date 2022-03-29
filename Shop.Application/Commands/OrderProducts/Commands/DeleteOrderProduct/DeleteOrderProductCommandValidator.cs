using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Interfaces;

namespace Shop.Application.Commands.OrderProducts.Commands.DeleteOrderProduct
{
    public class DeleteOrderProductCommandValidator
    : AbstractValidator<DeleteOrderProductCommand>
    {
        private readonly IDataBaseContext _dbContext;
        public DeleteOrderProductCommandValidator(IDataBaseContext dbContext)
        {
            _dbContext = dbContext;
            RuleFor(x => x.Id)
                .NotEmpty()
                .NotEqual(0)
                .WithMessage("The OrderProductId value must not equal to 0")
                .MustAsync(Exist)
                .WithMessage("The specified OrderProductId doesn't exist.");

        }
        
        public async Task<bool> Exist(long id, CancellationToken cancellationToken)
        {
            return await _dbContext.OrderProduct.AnyAsync(c => c.Id == id);
        }
    }
}
