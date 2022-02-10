using MediatR;
using Shop.Application.Orders.Queries.GetAllOrder;

namespace Shop.Application.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommand
        : IRequest<OrderVm>
    {
        public long Id { get; set; }
    }
}
