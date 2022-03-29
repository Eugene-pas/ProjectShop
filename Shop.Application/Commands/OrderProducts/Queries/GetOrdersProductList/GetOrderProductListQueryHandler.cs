using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Common;
using Shop.Application.Interfaces;

namespace Shop.Application.Commands.OrderProducts.Queries.GetOrdersProductList
{
    public class GetOrderProductListQueryHandler
        : HandlersBase, IRequestHandler<GetOrderProductListQuery, OrderProductListVm>
    {
        public GetOrderProductListQueryHandler(IDataBaseContext dbContext, IMapper mapper)
               : base(dbContext, mapper) { }

        public async Task<OrderProductListVm> Handle(GetOrderProductListQuery request,
            CancellationToken cancellationToken)
        {
            var Product = await _dbContext.OrderProduct
                .ProjectTo<OrderProductLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new OrderProductListVm { OrderProduct = Product };
        }
    }
}
