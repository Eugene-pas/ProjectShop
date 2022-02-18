using MediatR;
using Shop.Application.Categories.Commands.Queries.GetCategory;

namespace Shop.Application.Categories.Commands.CreateCategories
{
    public class CreateCategoryCommand 
        : IRequest<CategoryVm>
    {
        public long Id { get; set; }

        public string Name { get; set; }

    }
}
