using MediatR;

namespace Shop.Application.Commands.CategoryConnections.Commands.DeleteCategoryConnection
{
    public class DeleteCategoryConnectionCommand
        : IRequest<CategoryConnectionVm>
    {
        public long Id { get; set; }
    }
}
