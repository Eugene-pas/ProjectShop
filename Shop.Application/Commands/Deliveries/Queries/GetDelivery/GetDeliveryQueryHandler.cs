using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Common;
using Shop.Application.Exceptions;
using Shop.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Deliveries.Queries.GetDelivery
{
    public class GetDeliveryQueryHandler
        : HandlersBase, IRequestHandler<GetDeliveryQuery, DeliveryVm>
    {
        public GetDeliveryQueryHandler(IDataBaseContext dbContext, IMapper mapper)
            : base(dbContext, mapper) { }

        public async Task<DeliveryVm> Handle(GetDeliveryQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Delivery
                .FirstOrDefaultAsync(delivery => delivery.Id == request.Id, cancellationToken);

            _ = entity ?? throw new NotFoundException(nameof(Delivery), request.Id);

            return _mapper.Map<DeliveryVm>(entity);
        }
    }
}
