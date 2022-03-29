using MediatR;
using Shop.Application.Commands.OrderProducts.Queries;

namespace Shop.Application.Commands.OrderProducts.Commands.CreateOrderProduct
{
    public class CreateOrderProductCommand
        : IRequest<OrderProductVm>
    {
        public long OrderId { get; set; }

        public long ProductId { get; set; }
    }
}
