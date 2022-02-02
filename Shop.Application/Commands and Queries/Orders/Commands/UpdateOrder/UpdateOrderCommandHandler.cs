using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Exceptions;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommandHandler
        : IRequestHandler<UpdateOrderCommand>
    {
        private readonly IDataBaseContext _dbContext;
        public UpdateOrderCommandHandler(IDataBaseContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _dbContext.Order
                .FirstOrDefaultAsync(order =>
            order.Id == request.Id, cancellationToken);

            _ = order ?? throw new NotFoundException(nameof(Order), order.Id);

            order.Date = DateTime.Now;
            order.Adress = request.Adress;
            order.Customer = null;
            order.Delivery = null;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
