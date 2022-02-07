using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Orders.Commands.CreateOrder;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Commands_and_Queries.Orders.Commands.CreateOrder
{
    public class CreateOredrQueryValidator           
        : AbstractValidator<CreateOrderCommand>
    {
        private readonly IDataBaseContext _dbContext;
        
        public CreateOredrQueryValidator(IDataBaseContext dbContext)
        {
            _dbContext = dbContext;

            RuleFor(createOredrQuery =>
            createOredrQuery.Adress).NotEmpty().MaximumLength(250);
            RuleFor(createOredrQuery =>
            createOredrQuery.CustomerId).NotEqual(0)
                .WithMessage("The schoolId value must not equal to 0")
                .MustAsync(CustomerExist)
                .WithMessage("The specified CustomerId doesn't exist.");
            RuleFor(createOredrQuery =>
           createOredrQuery.DeliveryId).NotEqual(0)
               .WithMessage("The schoolId value must not equal to 0")
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
    }
}

