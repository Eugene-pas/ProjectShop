using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Shop.Application.Commands.Categories.Queries.GetCategoryPaginatedList;
using Shop.Application.Common;
using Shop.Application.Common.Pagination;
using Shop.Application.Exceptions;
using Shop.Application.Interfaces;

namespace Shop.Application.Commands.Orders.Queries.GetOrderPaginatedList
{
    public class GetOrderPaginatedListHandler
        : HandlersBase, IRequestHandler<GetOrderPaginatedListQuery, GetOrderPaginatedListVm>
    {
        public GetOrderPaginatedListHandler(IDataBaseContext dbContext, IMapper mapper)
            : base(dbContext, mapper)
        {
        }

        public async Task<GetOrderPaginatedListVm> Handle(GetOrderPaginatedListQuery request, CancellationToken cancellationToken)
        {
            var paginatedList = await PaginatedList<GetOrderPaginatedListDto>
                .CreateAsync(_dbContext.Order
                        .ProjectTo<GetOrderPaginatedListDto>(_mapper.ConfigurationProvider)
                        .Select(categories => categories),
                    request.Page, request.PageSize);
            if (request.Page > paginatedList.TotalPages)
            {
                throw new PageNotFoundException(request.Page);
            }
            return new GetOrderPaginatedListVm
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
