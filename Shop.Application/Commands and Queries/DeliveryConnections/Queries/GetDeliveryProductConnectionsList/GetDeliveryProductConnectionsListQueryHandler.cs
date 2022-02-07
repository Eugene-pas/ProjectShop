using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Commands_and_Queries.DeliveryConnections.Queries.GetDeliveryProductConnectionsList
{
    public class GetDeliveryProductConnectionsListQueryHandler
        : IRequestHandler<GetDeliveryProductConnectionsListQuery, DeliveryProductConnectionsListVm>
    {
        private readonly IDataBaseContext _dbContext;
        private readonly IMapper _mapper;

        public GetDeliveryProductConnectionsListQueryHandler(IDataBaseContext dbContext, IMapper mapper) =>
           (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<DeliveryProductConnectionsListVm> Handle(GetDeliveryProductConnectionsListQuery request,
            CancellationToken cancellationToken)
        {
            var connectionQuery = await _dbContext.DeliveryProductConnection
                .ProjectTo<DeliveryProductConnectionsDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return new DeliveryProductConnectionsListVm { ProductConnections = connectionQuery };
        }
    }
}
