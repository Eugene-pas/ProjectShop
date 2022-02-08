using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Categories.Commands.Queries.GetCategory
{
    public class GetCategoryQuery : IRequest<CategoryVm>
    {
        public long Id { get; set; }
    }
}
