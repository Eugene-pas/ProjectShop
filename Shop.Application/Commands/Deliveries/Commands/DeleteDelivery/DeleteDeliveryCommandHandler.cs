using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Shop.Application.Commands.Deliveries.Queries.GetDelivery;
using Shop.Application.Common;
using Shop.Application.Exceptions;
using Shop.Application.Interfaces;

namespace Shop.Application.Commands.Deliveries.Commands.DeleteDelivery
{
    public class DeleteDeliveryCommandHandler
        : HandlersBase, IRequestHandler<DeleteDeliveryCommand, DeliveryVm>
    {
        public DeleteDeliveryCommandHandler(IDataBaseContext dbContext, IMapper mapper)
            : base(dbContext, mapper) { }

        public async Task<DeliveryVm> Handle(DeleteDeliveryCommand request, CancellationToken cancellationToken)
        {
            var delivery = await _dbContext.Delivery
                .FindAsync(new object[] { request.Id }, cancellationToken);

            _ = delivery ?? throw new NotFoundException(nameof(DeleteDeliveryCommand), request.Id);

            _dbContext.Delivery.Remove(delivery);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return _mapper.Map<DeliveryVm>(delivery);
        }
    }
}
