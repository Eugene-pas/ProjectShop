using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Shop.Application.Common.Mappings;
using Shop.Domain.Entities;

namespace Shop.Application.Commands.CategoryConnections.Queries.GetCategoryConnectionsList
{
    public class ConnectionVm
    {
        public long Id { get; set; }
        public Category ParentCategory { get; set; }
        public Category ChildCategory { get; set; }

    }
}
