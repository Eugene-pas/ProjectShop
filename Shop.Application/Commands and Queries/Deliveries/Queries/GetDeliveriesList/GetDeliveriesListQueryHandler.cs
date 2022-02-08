using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Commands_and_Queries.Deliveries;
using Shop.Application.Customers.Commands;
using Shop.Application.Deliveries.Queries.GetDelivery;
using Shop.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Deliveries.Queries.GetDeliveriesList
{
    public class GetDeliveriesListQueryHandler
        : HandlersBase, IRequestHandler<GetDeliveriesListQuery, DeliveriesListVm>
    {
        private readonly IMapper _mapper;
        public GetDeliveriesListQueryHandler(IDataBaseContext dbContext, IMapper mapper) : base(dbContext)
            => _mapper = mapper;

        public async Task<DeliveriesListVm> Handle(GetDeliveriesListQuery request, CancellationToken cancellationToken)
        {
            var deliveriesQuery = await _dbContext.Delivery
                .ProjectTo<DeliveryVm>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new DeliveriesListVm { Deliveries = deliveriesQuery };
        }
    }
}
