using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Shop.Application.Commands.Orders.Queries.GetOrderPaginatedList
{
    public class GetOrderPaginatedListQuery
        : IRequest<OrderPaginatedListVm>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
