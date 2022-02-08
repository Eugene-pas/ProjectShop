using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Categories.Commands.DeleteCategories
{
    public class DeleteCategoryCommand
        : IRequest<Unit>
    {
        public long Id { get; set; }
    }
}
