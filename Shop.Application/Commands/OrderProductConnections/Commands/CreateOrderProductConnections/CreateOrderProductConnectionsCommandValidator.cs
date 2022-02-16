using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Commands_and_Queries.OrderProductConnections.Commands.CreateOrderProductConnections
{
    public class CreateOrderProductConnectionsCommandValidator
        : AbstractValidator<CreateOrderProductConnectionsCommand>
    {
        private readonly IDataBaseContext _dbContext;

        public CreateOrderProductConnectionsCommandValidator(IDataBaseContext dbContext)
        {
            _dbContext = dbContext;

            RuleFor(createConnection =>
            createConnection.OrderId).NotEmpty().NotEqual(0)
                .WithMessage("The OrderId value must not equal to 0")
                .MustAsync(OrderExist)
                .WithMessage("The specified OrderId doesn't exist.");
            RuleFor(createConnection =>
           createConnection.ProductId).NotEmpty().NotEqual(0)
               .WithMessage("The ProductId value must not equal to 0")
               .MustAsync(ProductExist)
               .WithMessage("The specified ProductId doesn't exist.");
        }
        public async Task<bool> OrderExist(long OrderId, CancellationToken cancellationToken)
        {
            return await _dbContext.Order
                .AnyAsync(o => o.Id == OrderId);
        }
        public async Task<bool> ProductExist(long ProductId, CancellationToken cancellationToken)
        {
            return await _dbContext.Product
                .AnyAsync(p => p.Id == ProductId);
        }
    }
}
