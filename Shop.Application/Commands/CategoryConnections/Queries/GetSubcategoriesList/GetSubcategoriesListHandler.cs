using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Shop.Application.Commands.CategoryConnections.Queries.GetCategoryConnectionsList;
using Shop.Application.Common;
using Shop.Application.Interfaces;
using Shop.Domain.Entities;

namespace Shop.Application.Commands.CategoryConnections.Queries.GetSubcategoriesList
{
    public class GetSubcategoriesListHandler
        : HandlersBase, IRequestHandler<GetSubcategoriesListQuery, SubcategoriesListVm>
    {
        public GetSubcategoriesListHandler(IDataBaseContext dbContext, IMapper mapper)
            : base(dbContext, mapper)
        {
        }

        public async Task<SubcategoriesListVm> Handle(GetSubcategoriesListQuery request, CancellationToken cancellationToken)
        {
            var listSubcategories = SubcategoriesFind(_dbContext, request.ParentId, new List<Category>());
            return new SubcategoriesListVm { CategoriesList = listSubcategories };
        }

        
    }
}
