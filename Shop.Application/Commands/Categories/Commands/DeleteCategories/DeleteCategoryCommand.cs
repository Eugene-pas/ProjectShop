using MediatR;
using Shop.Application.Categories.Commands.Queries.GetCategory;

namespace Shop.Application.Categories.Commands.DeleteCategories
{
    public class DeleteCategoryCommand
        : IRequest<CategoryVm>
    {
        public long Id { get; set; }
    }
}
