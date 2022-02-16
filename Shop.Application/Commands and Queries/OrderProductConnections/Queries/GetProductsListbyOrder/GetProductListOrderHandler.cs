using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Common;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Commands_and_Queries.OrderProductConnections.Queries.GetProductsListbyOrder
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
                .Where(order => order.Id == request.OrderId)
                .ProjectTo<GetProductListOrderLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            var TotalPrice = orderproductlist.Sum(x => x.Product.Price);

            return new GetProductListOrderVm { OrderProductConnection = orderproductlist, TotalPrice = TotalPrice };
        }
    }
}
