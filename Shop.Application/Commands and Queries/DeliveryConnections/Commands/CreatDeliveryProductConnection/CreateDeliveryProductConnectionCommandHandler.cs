using MediatR;
using AutoMapper;
using Shop.Application.Common;
using Shop.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using Shop.Application.DeliveryConnections.Queries;

namespace Shop.Application.Commands_and_Queries.DeliveryConnections.Commands.CreatDeliveryConnection
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
