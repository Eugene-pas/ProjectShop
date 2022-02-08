using MediatR;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Categories.Commands.UpdateCategories
{
    public class UpdateCategoryCommand
        : IRequest
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long ParentId { get; set; }
    }
}
