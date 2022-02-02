using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Customers.Commands;
using Shop.Application.Exceptions;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Deliveries.Commands.UpdateDelivery
{
    public class UpdateDeliveryCommandHandler
        : HandlersBase, IRequestHandler<UpdateDeliveryCommand>
    {
        public UpdateDeliveryCommandHandler(IDataBaseContext dbContext) : base(dbContext)
        {
        }

        public async Task<Unit> Handle(UpdateDeliveryCommand request, CancellationToken cancellationToken)
        {
            var delivery = await _dbContext.Delivery
                .FirstOrDefaultAsync(delivery =>
            delivery.Id == request.Id, cancellationToken);

            _ = delivery ?? throw new NotFoundException(nameof(Delivery), delivery.Id);

            delivery.Name = request.Name;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
