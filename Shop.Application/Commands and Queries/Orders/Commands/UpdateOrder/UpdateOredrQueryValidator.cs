using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Orders.Commands.UpdateOrder;
using Shop.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Commands_and_Queries.Orders.Commands.UpdateOrder
{
    public class UpdateOredrQueryValidator
   : AbstractValidator<UpdateOrderCommand>
    {
        private readonly IDataBaseContext _dbContext;
        public UpdateOredrQueryValidator(IDataBaseContext dbContext)
        {
            _dbContext = dbContext;
            RuleFor(createOredrQuery =>
            createOredrQuery.Id).NotEmpty().NotEqual(0)
                .WithMessage("The OredrId value must not equal to 0")
                .MustAsync(Exist)
                .WithMessage("The specified OredrId doesn't exist.");
            RuleFor(createOredrQuery =>
            createOredrQuery.Adress).NotEmpty().MaximumLength(250);
            RuleFor(createOredrQuery =>
           createOredrQuery.CustomerId).NotEqual(0)
               .WithMessage("The CustomerId value must not equal to 0")
               .MustAsync(CustomerExist)
               .WithMessage("The specified CustomerId doesn't exist.");
            RuleFor(createOredrQuery =>
           createOredrQuery.DeliveryId).NotEqual(0)
               .WithMessage("The DeliveryId value must not equal to 0")
               .MustAsync(DeliveryExist)
               .WithMessage("The specified DeliveryId doesn't exist.");
        }
        public async Task<bool> CustomerExist(long CustomerId, CancellationToken cancellationToken)
        {
            return await _dbContext.Customer
                .AnyAsync(c => c.Id == CustomerId);
        }
        public async Task<bool> DeliveryExist(long DeliveryId, CancellationToken cancellationToken)
        {
            return await _dbContext.Delivery
                .AnyAsync(p => p.Id == DeliveryId);
        }
        public async Task<bool> Exist(long OredrId, CancellationToken cancellationToken)
        {
            return await _dbContext.Order
                .AnyAsync(o => o.Id == OredrId);
        }
    }
}
