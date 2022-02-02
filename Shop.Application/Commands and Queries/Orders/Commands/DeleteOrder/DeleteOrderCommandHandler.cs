using MediatR;
using Shop.Application.Customers.Commands.DeleteCustomer;
using Shop.Application.Exceptions;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommandHandler
        : IRequestHandler<DeleteOrderCommand>
    {
        private readonly IDataBaseContext _dbContext;
        public DeleteOrderCommandHandler(IDataBaseContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _dbContext.Order
               .FindAsync(new object[] { request.Id }, cancellationToken);

            _ = order ?? throw new NotFoundException(nameof(Order), order.Id);
            _dbContext.Order.Remove(order);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
