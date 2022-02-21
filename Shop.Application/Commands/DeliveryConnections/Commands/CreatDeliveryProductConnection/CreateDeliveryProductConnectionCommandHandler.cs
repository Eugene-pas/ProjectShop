using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Shop.Application.Commands.DeliveryConnections.Queries;
using Shop.Application.Common;
using Shop.Application.Interfaces;
using Shop.Domain.Entities;

namespace Shop.Application.Commands.DeliveryConnections.Commands.CreatDeliveryProductConnection
{
    public class CreateDeliveryProductConnectionCommandHandler
        : HandlersBase, IRequestHandler<CreateDeliveryProductConnectionCommand, DeliveryProductConnectionVm>
    {
        public CreateDeliveryProductConnectionCommandHandler(IDataBaseContext dbContext, IMapper mapper)
             : base(dbContext, mapper) { }

        public async Task<DeliveryProductConnectionVm> Handle(CreateDeliveryProductConnectionCommand request, CancellationToken cancellationToken)
        {
            var conection = new DeliveryProductConnection
            {
                Delivery = _dbContext.Delivery.Find(request.DeliveryId),
                Product = _dbContext.Product.Find(request.ProductId)
            };

            await _dbContext.DeliveryProductConnection.AddAsync(conection, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return _mapper.Map<DeliveryProductConnectionVm>(conection);
        }
    }
}
