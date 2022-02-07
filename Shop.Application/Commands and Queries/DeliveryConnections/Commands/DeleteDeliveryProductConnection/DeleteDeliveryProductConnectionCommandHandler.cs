using MediatR;
using Shop.Application.Exceptions;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Commands_and_Queries.DeliveryConnections.Commands.DeleteDeliveryProductConnection
{
    public class DeleteDeliveryProductConnectionCommandHandler
         : IRequestHandler<DeleteDeliveryProductConnectionCommand>
    {
        private readonly IDataBaseContext _dbContext;
        public DeleteDeliveryProductConnectionCommandHandler(IDataBaseContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteDeliveryProductConnectionCommand request, CancellationToken cancellationToken)
        {
            var connection = await _dbContext.DeliveryProductConnection
                .FindAsync(new object[] { request.Id }, cancellationToken);
            _ = connection ?? throw new NotFoundException(nameof(Product), connection.Id);
            _dbContext.DeliveryProductConnection.Remove(connection);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
