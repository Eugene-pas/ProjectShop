using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Commands_and_Queries.Deliveries;
using Shop.Application.Customers.Commands;
using Shop.Application.Exceptions;
using Shop.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Deliveries.Queries.GetDelivery
{
    public class GetDeliveryQueryHandler
        : HandlersBase, IRequestHandler<GetDeliveryQuery, DeliveryVm>
    {
        private readonly IMapper _mapper;
        public GetDeliveryQueryHandler(IDataBaseContext dbContext, IMapper mapper) : base(dbContext)
        {
            _mapper = mapper;
        }

        public async Task<DeliveryVm> Handle(GetDeliveryQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Delivery
                .FirstOrDefaultAsync(delivery => delivery.Id == request.Id, cancellationToken);

            _ = entity ?? throw new NotFoundException(nameof(Delivery), request.Id);

            return _mapper.Map<DeliveryVm>(entity);
        }
    }
}
