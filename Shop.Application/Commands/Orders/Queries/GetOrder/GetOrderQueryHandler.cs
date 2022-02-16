using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shop.Domain.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Exceptions;
using Shop.Application.Common;
using AutoMapper.QueryableExtensions;
using System.Linq;

namespace Shop.Application.Orders.Queries.GetOrder
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
