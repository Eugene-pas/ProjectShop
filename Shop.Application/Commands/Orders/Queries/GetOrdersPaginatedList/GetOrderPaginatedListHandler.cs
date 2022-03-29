using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Shop.Application.Commands.Orders.Queries.GetOrdersList;
using Shop.Application.Common;
using Shop.Application.Common.Pagination;
using Shop.Application.Exceptions;
using Shop.Application.Interfaces;

namespace Shop.Application.Commands.Orders.Queries.GetOrderPaginatedList
{
    public class GetOrderPaginatedListHandler
        : HandlersBase, IRequestHandler<GetOrderPaginatedListQuery, OrderPaginatedListVm>
    {
        public GetOrderPaginatedListHandler(IDataBaseContext dbContext, IMapper mapper)
            : base(dbContext, mapper)
        {
        }

        public async Task<OrderPaginatedListVm> Handle(GetOrderPaginatedListQuery request, CancellationToken cancellationToken)
        {
            var paginatedList = await PaginatedList<OrdersLookupDto>
                .CreateAsync(_dbContext.Order
                        .ProjectTo<OrdersLookupDto>(_mapper.ConfigurationProvider)
                        .Select(categories => categories), request.Page, request.PageSize);

            if (request.Page > paginatedList.TotalPages)
            {
                throw new PageNotFoundException(request.Page);
            }

            return new OrderPaginatedListVm
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
