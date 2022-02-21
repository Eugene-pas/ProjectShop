using MediatR;
using Shop.Application.Categories.Commands.Queries.GetCategory;

namespace Shop.Application.Categories.Commands.UpdateCategories
{
    public class UpdateCategoryCommand
        : IRequest<CategoryVm>
    {
        public long CategoryId { get; set; }

        public string Name { get; set; }

    }
}
