using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Commands.Orders.Queries.GetOrderPaginatedList;
using Shop.Application.Commands.Orders.Queries.GetOrdersList;
using Shop.Application.Common;
using Shop.Application.Common.Pagination;
using Shop.Application.Exceptions;
using Shop.Application.Interfaces;

namespace Shop.Application.Commands.Orders.Queries.GetOrderPaginatedListForCustomer
{
    public class GetOrderPaginatedListForCustomerHandler
        : HandlersBase, IRequestHandler<GetOrderPaginatedListForCustomerQuery, OrderPaginatedListForCustomerVm>
    {
        public GetOrderPaginatedListForCustomerHandler(IDataBaseContext dbContext, IMapper mapper)
            : base(dbContext, mapper)
        {
        }

        public async Task<OrderPaginatedListForCustomerVm> Handle(GetOrderPaginatedListForCustomerQuery request, CancellationToken cancellationToken)
        {
            var paginatedList = await PaginatedList<OrdersLookupDto>
                .CreateAsync(_dbContext.Order
                        .ProjectTo<OrdersLookupDto>(_mapper.ConfigurationProvider)
                        .Where(order => order.Customer.Id == request.CustomerId)
                        .Select(categories => categories), request.Page, request.PageSize);

            if (request.Page > paginatedList.TotalPages)
            {
                throw new PageNotFoundException(request.Page);
            }

            return new OrderPaginatedListForCustomerVm
            {
                ListOrders = paginatedList,
                Page = request.Page,
                TotalPage = paginatedList.TotalPages,
                HasNextPage = paginatedList.HasNextPage,
                HasPreviousPage = paginatedList.HasPreviousPage
            };
        }
    }
}
