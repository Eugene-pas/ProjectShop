using MediatR;

namespace Shop.Application.Categories.Commands.Queries.GetCategory
{
    public class GetCategoryQuery : IRequest<CategoryVm>
    {
        public long Id { get; set; }       
    }
}
