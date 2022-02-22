using MediatR;
using Shop.Application.Commands.Categories.Queries.GetCategoryList;

namespace Shop.Application.Commands.Categories.Queries.GetCategoryPaginatedList
{
    public class GetCategoryPaginatedListQuery
        : IRequest<GetCategoryPaginatedListVm>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
