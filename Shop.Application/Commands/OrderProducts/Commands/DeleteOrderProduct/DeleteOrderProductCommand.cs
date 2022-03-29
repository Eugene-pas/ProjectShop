using MediatR;
using Shop.Application.Commands.OrderProducts.Queries;

namespace Shop.Application.Commands.OrderProducts.Commands.DeleteOrderProduct
{
    public class DeleteOrderProductCommand
        : IRequest<OrderProductVm>
    {
        public long Id { get; set; }
    }
}
