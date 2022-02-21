using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Commands.CategoryConnections.Queries.GetCategoryConnectionsList
{
    public class GetCategoryConnectionsListQuery
        : IRequest<GetCategoryConnectionsListVm>
    {
    }
}
