﻿using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Commands.Orders.Queries.GetOrdersList;
using Shop.Application.Exceptions;
using Shop.Application.Interfaces;
using Shop.Domain.Entities;

namespace Shop.Application.Commands.Orders.Queries.GetOrdersListForCustomer
{
    public class GetOrdersListForCustomerHandler
        : IRequestHandler<GetOrdersListForCustomerQuery, OrderListVm>
    {
        private readonly IDataBaseContext _dbContext;
        private readonly IMapper _mapper;

        public GetOrdersListForCustomerHandler(IDataBaseContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<OrderListVm> Handle(GetOrdersListForCustomerQuery request, CancellationToken cancellationToken)
        {
            var orders = await _dbContext.Order.Include(x => x.Customer)
                .Where(order =>
                order.Customer.Id == request.customerId)
                .ProjectTo<OrderLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            if(orders.Count == 0) orders = null;

            _ = orders ?? throw new NotFoundException(nameof(Order), $"CategoryId :{request.customerId}");

             return new OrderListVm { Order = orders };
        }
    }
}
