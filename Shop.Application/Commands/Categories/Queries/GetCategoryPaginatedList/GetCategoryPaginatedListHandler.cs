using AutoMapper;
using MediatR;
using Shop.Application.Common;
using Shop.Application.Interfaces;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Server.HttpSys;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Common.Pagination;
using Shop.Domain.Entities;

namespace Shop.Application.Commands.Categories.Queries.GetCategoryPaginatedList
{
    public class GetCategoryPaginatedListHandler
        : HandlersBase, IRequestHandler<GetCategoryPaginatedListQuery, GetCategoryPaginatedListVm>
    {
        public GetCategoryPaginatedListHandler(IDataBaseContext dbContext, IMapper mapper)
            : base(dbContext, mapper) { }

        public async Task<GetCategoryPaginatedListVm> Handle(GetCategoryPaginatedListQuery request, CancellationToken cancellationToken)
        {
            var categories = from c in _dbContext.Category
                .ProjectTo<GetCategoryPaginatedListDto>(_mapper.ConfigurationProvider) select c;
            
            var paginatedList = await PaginatedList<GetCategoryPaginatedListDto>
                .CreateAsync(categories, request.Page, request.PageSize);
            
            return new GetCategoryPaginatedListVm 
            {
                ListCategory = paginatedList,
                Page = request.Page, 
                TotalPage = paginatedList.TotalPages,
                HasNextPage = paginatedList.HasNextPage,
                HasPreviousPage = paginatedList.HasPreviousPage
            };
        }
    }
}
