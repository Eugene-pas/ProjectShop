using MediatR;
using Shop.Application.Commands.Orders.Queries.GetOrder;

namespace Shop.Application.Commands.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommand
        : IRequest<OrderVm>
    {
        public long Id { get; set; }
    }
}
