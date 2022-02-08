using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Commands_and_Queries.OrderProductConnections.Queries.GetOrdersListProductConnections
{
    public class GetOrderProductConnectionsListQueryHandler
    : IRequestHandler<GetOrderProductConnectionsListQuery, OrderProductConnectionListVm>
    {
        private readonly IDataBaseContext _dbContext;
        private readonly IMapper _mapper;
        public GetOrderProductConnectionsListQueryHandler(IDataBaseContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<OrderProductConnectionListVm> Handle(GetOrderProductConnectionsListQuery request,
            CancellationToken cancellationToken)
        {
            var orderProductConnection = await _dbContext.OrderProductConnection
                .ProjectTo<OrderProductConnectionLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new OrderProductConnectionListVm { OrderProductConnection = orderProductConnection };
        }
    }
}
