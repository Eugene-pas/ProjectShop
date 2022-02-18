using MediatR;

namespace Shop.Application.Commands.CategoryConnections.Queries.GetSubcategoriesList
{
    public class GetSubcategoriesListQuery
    : IRequest<SubcategoriesListVm>
    {
        public long ParentId { get; set; }
    }
}
