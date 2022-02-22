using MediatR;

namespace Shop.Application.Commands.Categories.Queries.GetCategory
{
    public class GetCategoryQuery : IRequest<CategoryVm>
    {
        public long Id { get; set; }       
    }
}
