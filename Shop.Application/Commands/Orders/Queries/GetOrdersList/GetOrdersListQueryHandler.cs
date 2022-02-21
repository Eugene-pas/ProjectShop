using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Interfaces;

namespace Shop.Application.Commands.Orders.Queries.GetOrdersList
{
    public class GetOrdersListQueryHandler
        : IRequestHandler<GetOrdersListQuery, OrderListVm>
    {
        private readonly IDataBaseContext _dbContext;
        private readonly IMapper _mapper;
        public GetOrdersListQueryHandler(IDataBaseContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<OrderListVm> Handle(GetOrdersListQuery request, CancellationToken cancellationToken)
        {
            var order = await _dbContext.Order
                .ProjectTo<OrderLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
                    
            return  new OrderListVm { Order = order };
        }
    }
}
