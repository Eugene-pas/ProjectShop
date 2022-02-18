using MediatR;

namespace Shop.Application.Commands.CategoryConnections.Commands.UpdateCategoryConnection
{
    public class UpdateCategoryConnectionCommand
        :IRequest<CategoryConnectionVm>
    {
        public long Id { get; set; }

        public long ParentId { get; set; }

        public long ChildId { get; set; }
    }
}
