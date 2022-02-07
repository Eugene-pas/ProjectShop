using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Orders.Commands.DeleteOrder;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Commands_and_Queries.Orders.Commands.DeleteOrder
{
    public class DeleteOredrQueryValidator
   : AbstractValidator<DeleteOrderCommand>
    {
        private readonly IDataBaseContext _dbContext;
        public DeleteOredrQueryValidator(IDataBaseContext dbContext)
        {
            _dbContext = dbContext;
            RuleFor(createOredrQuery =>
            createOredrQuery.Id).NotEmpty().NotEqual(0)
                .WithMessage("The schoolId value must not equal to 0")
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
