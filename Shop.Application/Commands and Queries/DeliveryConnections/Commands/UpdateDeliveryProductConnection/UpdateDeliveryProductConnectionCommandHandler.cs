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

namespace Shop.Application.Commands_and_Queries.DeliveryConnections.Commands.UpdateDeliveryProductConnection
{
    public class UpdateDeliveryProductConnectionCommandHandler
        : IRequestHandler<UpdateDeliveryProductConnectionCommand>
    {
        private readonly IDataBaseContext _dbContext;
        public UpdateDeliveryProductConnectionCommandHandler(IDataBaseContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateDeliveryProductConnectionCommand request, CancellationToken cancellationToken)
        {
            var connection = await _dbContext.DeliveryProductConnection
                .FirstOrDefaultAsync(connection =>
                connection.Id == request.Id, cancellationToken);

            _ = connection ?? throw new NotFoundException(nameof(DeliveryProductConnection), connection.Id);

            connection.Product = _dbContext.Product.Find(request.ProductId);
            connection.Delivery = _dbContext.Delivery.Find(request.DeliveryId);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
