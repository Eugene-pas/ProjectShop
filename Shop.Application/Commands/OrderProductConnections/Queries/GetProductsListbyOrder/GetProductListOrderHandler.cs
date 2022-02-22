using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Common;
using Shop.Application.Interfaces;

namespace Shop.Application.Commands.OrderProductConnections.Queries.GetProductsListbyOrder
{
    public class GetProductListOrderHandler
    : HandlersBase, IRequestHandler<GetProductListOrderQuery, GetProductListOrderVm>
    {
        public GetProductListOrderHandler(IDataBaseContext dbContext, IMapper mapper)
              : base(dbContext, mapper) { }

        public async Task<GetProductListOrderVm> Handle(GetProductListOrderQuery request,
            CancellationToken cancellationToken)
        {
            var orderproductlist = await _dbContext.OrderProductConnection
                .Include(x => x.Order)
                .Where(order => order.Order.Id == request.OrderId)
                .ProjectTo<GetProductListOrderLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            var TotalPrice = orderproductlist.Sum(x => x.Product.Price);

            return new GetProductListOrderVm { OrderProductConnection = orderproductlist, TotalPrice = TotalPrice };
        }
    }
}
