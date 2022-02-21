using MediatR;
using Shop.Application.Commands.Categories.Queries.GetCategory;

namespace Shop.Application.Commands.Categories.Commands.CreateCategories
{
    public class CreateCategoryCommand 
        : IRequest<CategoryVm>
    {
        public long Id { get; set; }

        public string Name { get; set; }

    }
}
