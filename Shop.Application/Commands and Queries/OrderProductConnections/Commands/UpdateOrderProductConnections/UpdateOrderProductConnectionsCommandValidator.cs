using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Commands_and_Queries.OrderProductConnections.Commands.UpdateOrderProductConnections
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
                .WithMessage("The Id value must not equal to 0")
                .MustAsync(Exist)
                .WithMessage("The specified Id doesn't exist.");
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
