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
using Shop.Application.Common;

namespace Shop.Application.Commands_and_Queries.DeliveryConnections.Queries.GetDeliveryProductConnectionsList
{
    public class GetDeliveryProductConnectionsListQueryHandler
        : HandlersBase, IRequestHandler<GetDeliveryProductConnectionsListQuery, DeliveryProductConnectionsListVm>
    {
        public GetDeliveryProductConnectionsListQueryHandler(IDataBaseContext dbContext, IMapper mapper)
            : base(dbContext, mapper) { }

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
