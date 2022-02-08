using MediatR;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Categories.Commands.CreateCategories
{
    public class CreateCategoryCommand 
        : IRequest<long>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long parentId { get; set; }
    }
}
