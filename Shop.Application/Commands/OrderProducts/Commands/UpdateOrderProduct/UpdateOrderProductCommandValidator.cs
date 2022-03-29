using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Interfaces;

namespace Shop.Application.Commands.OrderProducts.Commands.UpdateOrderProduct
{
    public class UpdateOrderProductCommandValidator
    : AbstractValidator<UpdateOrderProductCommand>
    {
        private readonly IDataBaseContext _dbContext;
        public UpdateOrderProductCommandValidator(IDataBaseContext dbContext)
        {
            _dbContext = dbContext;
            
            RuleFor(x => x.Id)
                .NotEmpty()
                .NotEqual(0)
                .WithMessage("The CategoryId value must not equal to 0")
                .MustAsync(Exist)
                .WithMessage("The specified CategoryId doesn't exist.");
            RuleFor(x => x.ProductId)
                .NotEqual(0)
                .WithMessage("The ProductId value must not equal to 0")
                .MustAsync(ProductExist)
                .WithMessage("The specified ProductId doesn't exist.");
            RuleFor(x => x.OrderId)
                .NotEqual(0)
                .WithMessage("The OrderId value must not equal to 0")
                .MustAsync(OredrExist)
                .WithMessage("The specified OrderId doesn't exist.");
        }
        public async Task<bool> ProductExist(long Id, CancellationToken cancellationToken)
        {
            return await _dbContext.Customer.AnyAsync(x => x.Id == Id);
        }
        public async Task<bool> OredrExist(long Id, CancellationToken cancellationToken)
        {
            return await _dbContext.Delivery.AnyAsync(x => x.Id == Id);
        }
        public async Task<bool> Exist(long Id, CancellationToken cancellationToken)
        {
            return await _dbContext.OrderProduct.AnyAsync(x => x.Id == Id);
        }
    }
}
