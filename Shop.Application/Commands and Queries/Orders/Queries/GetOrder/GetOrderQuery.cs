using MediatR;

namespace Shop.Application.Orders.Queries.GetOrder
{
    public class GetOrderQuery : IRequest<OrderVm>
    {
        public long Id { get; set; }
    }
}
