using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Shop.Application.Commands.Orders.Queries.GetOrderPaginatedList
{
    internal class GetOrderPaginatedListQuery
        : IRequest<GetOrderPaginatedListVm>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
