using MediatR;
using Shop.Application.Customers.Commands;
using Shop.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Deliveries.Commands.CreateDelivery
{
    public class CreateDeliveryCommandHandler
        : HandlersBase, IRequestHandler<CreateDeliveryCommand, long>
    {
        public CreateDeliveryCommandHandler(IDataBaseContext dbContext) : base(dbContext) { }
        
        public async Task<long> Handle(CreateDeliveryCommand request, CancellationToken cancellationToken)
        {
            var delivery = new Delivery
            {
                Name = request.Name,
                Order = null,
                DeliveryProductConnection = null
            };
            await _dbContext.Delivery.AddAsync(delivery, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return delivery.Id;
        }
    }
}
