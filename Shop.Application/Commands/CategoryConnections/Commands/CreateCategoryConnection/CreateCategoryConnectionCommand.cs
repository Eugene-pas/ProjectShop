using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Commands.CategoryConnections.Commands.CreateCategoryConnection
{
    public class CreateCategoryConnectionCommand
    :IRequest<CategoryConnectionVm>
    {
        public long ParentId { get; set; }

        public long ChildId { get; set; }
    }
}
