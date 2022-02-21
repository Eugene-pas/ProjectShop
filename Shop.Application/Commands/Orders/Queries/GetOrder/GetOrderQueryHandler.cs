using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Common;
using Shop.Application.Interfaces;

namespace Shop.Application.Commands.Orders.Queries.GetOrder
{
    public class GetOrderQueryHandler : HandlersBase, IRequestHandler<GetOrderQuery, OrderVm>
    {
        public GetOrderQueryHandler(IDataBaseContext dbContext, IMapper mapper)
            : base(dbContext, mapper) { }

        public async Task<OrderVm> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            var orderquery = await _dbContext.Order
                .ProjectTo<OrderVm>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return orderquery.FirstOrDefault(x => x.Id == request.Id);
        }
    }
}
