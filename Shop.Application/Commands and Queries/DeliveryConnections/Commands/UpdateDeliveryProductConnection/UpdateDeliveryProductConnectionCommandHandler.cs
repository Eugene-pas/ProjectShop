using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Common;
using Shop.Application.DeliveryConnections.Queries;
using Shop.Application.Exceptions;
using Shop.Domain.Entities;

namespace Shop.Application.Commands_and_Queries.DeliveryConnections.Commands.UpdateDeliveryProductConnection
{
    public class UpdateDeliveryProductConnectionCommandHandler
        : HandlersBase, IRequestHandler<UpdateDeliveryProductConnectionCommand, DeliveryProductConnectionVm>
    {
        public UpdateDeliveryProductConnectionCommandHandler(IDataBaseContext dbContext, IMapper mapper)
            : base(dbContext, mapper) { }

        public async Task<DeliveryProductConnectionVm> Handle(UpdateDeliveryProductConnectionCommand request, CancellationToken cancellationToken)
        {
            var connection = await _dbContext.DeliveryProductConnection
                .FirstOrDefaultAsync(connection =>
                connection.Id == request.Id, cancellationToken);

            _ = connection ?? throw new NotFoundException(nameof(DeliveryProductConnection), connection.Id);

            connection.Product = _dbContext.Product.Find(request.ProductId);
            connection.Delivery = _dbContext.Delivery.Find(request.DeliveryId);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return _mapper.Map<DeliveryProductConnectionVm>(connection);
        }
    }
}
