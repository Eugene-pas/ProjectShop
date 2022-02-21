using MediatR;

namespace Shop.Application.Commands.CategoryConnections.Commands.CreateCategoryConnection
{
    public class CreateCategoryConnectionCommand
    :IRequest<CategoryConnectionVm>
    {
        public long ParentId { get; set; }

        public long ChildId { get; set; }
    }
}
