using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Interfaces;

namespace Shop.Application.Commands.Orders.Commands.CreateOrder
{
    public class CreateOrderQueryValidator           
        : AbstractValidator<CreateOrderCommand>
    {
        private readonly IDataBaseContext _dbContext;
        
        public CreateOrderQueryValidator(IDataBaseContext dbContext)
        {
            _dbContext = dbContext;

            RuleFor(createOrderQuery =>
            createOrderQuery.Adress).NotEmpty().MaximumLength(250);
            RuleFor(createOrderQuery =>
            createOrderQuery.CustomerId).NotEqual(0)
                .WithMessage("The CustomerId value must not equal to 0")
                .MustAsync(CustomerExist)
                .WithMessage("The specified CustomerId doesn't exist.");
            RuleFor(createOrderQuery =>
           createOrderQuery.DeliveryId).NotEqual(0)
               .WithMessage("The DeliveryId value must not equal to 0")
               .MustAsync(DeliveryExist)
               .WithMessage("The specified DeliveryId doesn't exist.");

        }
        public async Task<bool> CustomerExist(long customerId, CancellationToken cancellationToken)
        {
            return await _dbContext.Customer
                .AnyAsync(c => c.Id == customerId, cancellationToken);
        }
        public async Task<bool> DeliveryExist(long deliveryId, CancellationToken cancellationToken)
        {
            return await _dbContext.Delivery
                .AnyAsync(p => p.Id == deliveryId, cancellationToken);
        }
    }
}

