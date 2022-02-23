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
using Shop.Application.Common;
using Shop.Application.Common.Pagination;
using Shop.Application.Exceptions;
using Shop.Application.Interfaces;

namespace Shop.Application.Commands.Orders.Queries.GetOrderPaginatedListForCustomer
{
    public class GetOrderPaginatedListForCustomerHandler
        : HandlersBase, IRequestHandler<GetOrderPaginatedListForCustomerQuery, GetOrderPaginatedListForCustomerVm>
    {
        public GetOrderPaginatedListForCustomerHandler(IDataBaseContext dbContext, IMapper mapper)
            : base(dbContext, mapper)
        {
        }

        public async Task<GetOrderPaginatedListForCustomerVm> Handle(GetOrderPaginatedListForCustomerQuery request, CancellationToken cancellationToken)
        {
            var paginatedList = await PaginatedList<GetOrderPaginatedListForCustomerDto>
                .CreateAsync(_dbContext.Order
                        .Include(order => order.Customer)
                        .ProjectTo<GetOrderPaginatedListForCustomerDto>(_mapper.ConfigurationProvider)
                        .Where(order => order.Customer.Id == request.CustomerId)
                        .Select(categories => categories),
                    request.Page, request.PageSize);
            if (request.Page > paginatedList.TotalPages)
            {
                throw new PageNotFoundException(request.Page);
            }
            return new GetOrderPaginatedListForCustomerVm
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
