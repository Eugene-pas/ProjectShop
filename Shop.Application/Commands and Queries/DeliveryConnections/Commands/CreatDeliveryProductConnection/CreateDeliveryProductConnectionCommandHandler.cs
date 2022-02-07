using MediatR;
using Shop.Application.Customers.Commands;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Commands_and_Queries.DeliveryConnections.Commands.CreatDeliveryConnection
{
    public class CreateDeliveryProductConnectionCommandHandler
        : HandlersBase, IRequestHandler<CreateDeliveryProductConnectionCommand, long>
    {
        public CreateDeliveryProductConnectionCommandHandler(IDataBaseContext dbContext) : base(dbContext) { }
        public async Task<long> Handle(CreateDeliveryProductConnectionCommand request, CancellationToken cancellationToken)
        {
            var conection = new DeliveryProductConnection
            {
                Delivery = _dbContext.Delivery.Find(request.DeliveryId),
                Product = _dbContext.Product.Find(request.ProductId)
            };
            await _dbContext.DeliveryProductConnection.AddAsync(conection, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return conection.Id;
        }
    }
}
