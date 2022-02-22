using MediatR;

namespace Shop.Application.Commands.Orders.Queries.GetOrder
{
    public class GetOrderQuery : IRequest<OrderVm>
    {
        public long Id { get; set; }
    }
}
