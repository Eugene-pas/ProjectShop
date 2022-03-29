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
            var product = await _dbContext.Order
                .Include(x => x.Customer)
                .Include(x => x.OrderProduct).ThenInclude(x => x.Product)
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            return _mapper.Map<OrderVm>(product);
        }
    }
}
