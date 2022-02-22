using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Interfaces;

namespace Shop.Application.Commands.OrderProductConnections.Commands.UpdateOrderProductConnections
{
    public class UpdateOrderProductConnectionsCommandValidator
    : AbstractValidator<UpdateOrderProductConnectionsCommand>
    {
        private readonly IDataBaseContext _dbContext;
        public UpdateOrderProductConnectionsCommandValidator(IDataBaseContext dbContext)
        {
            _dbContext = dbContext;
            RuleFor(connection =>
            connection.Id).NotEmpty().NotEqual(0)
                .WithMessage("The CategoryId value must not equal to 0")
                .MustAsync(Exist)
                .WithMessage("The specified CategoryId doesn't exist.");
            RuleFor(connectionProduct =>
           connectionProduct.ProductId).NotEqual(0)
               .WithMessage("The ProductId value must not equal to 0")
               .MustAsync(ProductExist)
               .WithMessage("The specified ProductId doesn't exist.");
            RuleFor(connectionOredr =>
           connectionOredr.OrderId).NotEqual(0)
               .WithMessage("The OredrId value must not equal to 0")
               .MustAsync(OredrExist)
               .WithMessage("The specified OredrId doesn't exist.");
        }
        public async Task<bool> ProductExist(long ProductId, CancellationToken cancellationToken)
        {
            return await _dbContext.Customer
                .AnyAsync(c => c.Id == ProductId);
        }
        public async Task<bool> OredrExist(long OredrId, CancellationToken cancellationToken)
        {
            return await _dbContext.Delivery
                .AnyAsync(p => p.Id == OredrId);
        }
        public async Task<bool> Exist(long Id, CancellationToken cancellationToken)
        {
            return await _dbContext.OrderProductConnection
                .AnyAsync(o => o.Id == Id);
        }
    }
}
