using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Commands.OrderProducts.Queries.GetOrdersProductList;
using Shop.Application.Common;
using Shop.Application.Interfaces;

namespace Shop.Application.Commands.OrderProducts.Queries.GetProductsListbyOrder
{
    public class GetProductListOrderHandler
    : HandlersBase, IRequestHandler<GetProductListOrderQuery, ProductListByOrderVm>
    {
        public GetProductListOrderHandler(IDataBaseContext dbContext, IMapper mapper)
              : base(dbContext, mapper) { }

        public async Task<ProductListByOrderVm> Handle(GetProductListOrderQuery request,
            CancellationToken cancellationToken)
        {
            var Product = await _dbContext.OrderProduct
                .Where(order => order.Order.Id == request.OrderId)
                .ProjectTo<OrderProductLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var TotalPrice = Product.Sum(x => x.Product.Price);

            return new ProductListByOrderVm { OrderProduct = Product, TotalPrice = TotalPrice };
        }
    }
}
