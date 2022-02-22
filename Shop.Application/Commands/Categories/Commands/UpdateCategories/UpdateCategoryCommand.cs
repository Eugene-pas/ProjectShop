using MediatR;
using Shop.Application.Commands.Categories.Queries.GetCategory;

namespace Shop.Application.Commands.Categories.Commands.UpdateCategories
{
    public class UpdateCategoryCommand
        : IRequest<CategoryVm>
    {
        public long CategoryId { get; set; }

        public string Name { get; set; }

    }
}
