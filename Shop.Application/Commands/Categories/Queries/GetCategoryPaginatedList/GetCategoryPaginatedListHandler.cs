using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Shop.Application.Common;
using Shop.Application.Common.Pagination;
using Shop.Application.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Shop.Application.Exceptions;

namespace Shop.Application.Commands.Categories.Queries.GetCategoryPaginatedList
{
    public class GetCategoryPaginatedListHandler
        : HandlersBase, IRequestHandler<GetCategoryPaginatedListQuery, GetCategoryPaginatedListVm>
    {
        public GetCategoryPaginatedListHandler(IDataBaseContext dbContext, IMapper mapper)
            : base(dbContext, mapper) { }

        public async Task<GetCategoryPaginatedListVm> Handle(GetCategoryPaginatedListQuery request, CancellationToken cancellationToken)
        {
            
            var paginatedList = await PaginatedList<GetCategoryPaginatedListDto>
                .CreateAsync(_dbContext.Category
                    .ProjectTo<GetCategoryPaginatedListDto>(_mapper.ConfigurationProvider)
                    .Select(categories => categories),
                    request.Page, request.PageSize);
            if (request.Page > paginatedList.TotalPages)
            {
                throw new PageNotFoundException(request.Page);
            }
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
