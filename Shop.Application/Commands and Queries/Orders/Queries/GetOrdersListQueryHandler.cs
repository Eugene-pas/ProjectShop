using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Exceptions;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Orders.Queries.GetAllOrder
{
    public class GetOrdersListQueryHandler
        : IRequestHandler<GetOrdersListQuery, OrderVm>
    {
        private readonly IDataBaseContext _dbContext;
        private readonly IMapper _mapper;
        public GetOrdersListQueryHandler(IDataBaseContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<OrderVm> Handle(GetOrdersListQuery request, CancellationToken cancellationToken)
        {
            var order = await _dbContext.Order
                .ProjectTo<OrderLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
                    
            return  new OrderVm { Order = order };
        }
    }
}
