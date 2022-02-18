using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Commands.CategoryConnections.Commands.DeleteCategoryConnection
{
    public class DeleteCategoryConnectionCommand
        : IRequest<CategoryConnectionVm>
    {
        public long Id { get; set; }
    }
}
