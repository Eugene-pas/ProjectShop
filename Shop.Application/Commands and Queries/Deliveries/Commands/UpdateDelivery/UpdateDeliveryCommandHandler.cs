using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Deliveries.Queries.GetDelivery;
using Shop.Application.Common;
using Shop.Application.Exceptions;
using Shop.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Deliveries.Commands.UpdateDelivery
{
    public class UpdateDeliveryCommandHandler
        : HandlersBase, IRequestHandler<UpdateDeliveryCommand, DeliveryVm>
    {
        public UpdateDeliveryCommandHandler(IDataBaseContext dbContext, IMapper mapper)
            : base(dbContext, mapper) { }

        public async Task<DeliveryVm> Handle(UpdateDeliveryCommand request, CancellationToken cancellationToken)
        {
            var delivery = await _dbContext.Delivery
                .FirstOrDefaultAsync(delivery =>
            delivery.Id == request.Id, cancellationToken);

            _ = delivery ?? throw new NotFoundException(nameof(Delivery), delivery.Id);

            delivery.Name = request.Name;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return _mapper.Map<DeliveryVm>(delivery);
        }
    }
}
