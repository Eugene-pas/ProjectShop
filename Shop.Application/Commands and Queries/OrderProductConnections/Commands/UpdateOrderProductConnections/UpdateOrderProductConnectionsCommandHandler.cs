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

namespace Shop.Application.Commands_and_Queries.OrderProductConnections.Commands.UpdateOrderProductConnections
{
    public class UpdateOrderProductConnectionsCommandHandler
    : IRequestHandler<UpdateOrderProductConnectionsCommand>
    {
        private readonly IDataBaseContext _dbContext;

        public UpdateOrderProductConnectionsCommandHandler(IDataBaseContext dbContext) =>
            _dbContext = dbContext;
        
        public async Task<Unit> Handle(UpdateOrderProductConnectionsCommand request, CancellationToken cancellationToken)
        {
            var connection = await _dbContext.OrderProductConnection
                .FirstOrDefaultAsync(customer =>
            customer.Id == request.Id, cancellationToken);

            _ = connection ?? throw new NotFoundException(nameof(OrderProductConnection), connection.Id);

            connection.Product = _dbContext.Product.Find(request.ProductId);
            connection.Order = _dbContext.Order.Find(request.OrderId);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
