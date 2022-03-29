using MediatR;
using Shop.Application.Commands.OrderProducts.Queries;

namespace Shop.Application.Commands.OrderProducts.Commands.UpdateOrderProduct
{
    public class UpdateOrderProductCommand
        : IRequest<OrderProductVm>
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public long ProductId { get; set; }
    }
}
