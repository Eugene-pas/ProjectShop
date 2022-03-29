using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Interfaces;

namespace Shop.Application.Commands.OrderProducts.Commands.CreateOrderProduct
{
    public class CreateOrderProductCommandValidator
        : AbstractValidator<CreateOrderProductCommand>
    {
        private readonly IDataBaseContext _dbContext;

        public CreateOrderProductCommandValidator(IDataBaseContext dbContext)
        {
            _dbContext = dbContext;

            RuleFor(x => x.OrderId)
                .NotEmpty()
                .NotEqual(0)
                .WithMessage("The OrderId value must not equal to 0")
                .MustAsync(OrderExist)
                .WithMessage("The specified OrderId doesn't exist.");
            RuleFor(x => x.ProductId)
               .NotEmpty()
               .NotEqual(0)
               .WithMessage("The ProductId value must not equal to 0")
               .MustAsync(ProductExist)
               .WithMessage("The specified ProductId doesn't exist.");
        }
        public async Task<bool> OrderExist(long id, CancellationToken cancellationToken)
        {
            return await _dbContext.Order.AnyAsync(x => x.Id == id);
        }
        public async Task<bool> ProductExist(long id, CancellationToken cancellationToken)
        {
            return await _dbContext.Product.AnyAsync(x => x.Id == id);
        }
    }
}
