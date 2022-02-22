using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Commands.Deliveries.Queries.GetDelivery;
using Shop.Application.Common;
using Shop.Application.Interfaces;

namespace Shop.Application.Commands.Deliveries.Queries.GetDeliveriesList
{
    public class GetDeliveriesListQueryHandler
        : HandlersBase, IRequestHandler<GetDeliveriesListQuery, DeliveriesListVm>
    {
        public GetDeliveriesListQueryHandler(IDataBaseContext dbContext, IMapper mapper)
            : base(dbContext, mapper) { }

        public async Task<DeliveriesListVm> Handle(GetDeliveriesListQuery request, CancellationToken cancellationToken)
        {
            var deliveriesQuery = await _dbContext.Delivery
                .ProjectTo<DeliveryVm>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new DeliveriesListVm { Deliveries = deliveriesQuery };
        }
    }
}
