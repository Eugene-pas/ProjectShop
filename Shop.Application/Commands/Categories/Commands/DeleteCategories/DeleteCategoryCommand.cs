using MediatR;
using Shop.Application.Commands.Categories.Queries.GetCategory;

namespace Shop.Application.Commands.Categories.Commands.DeleteCategories
{
    public class DeleteCategoryCommand
        : IRequest<CategoryVm>
    {
        public long Id { get; set; }
    }
}
