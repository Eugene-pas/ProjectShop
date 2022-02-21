using MediatR;

namespace Shop.Application.Commands.OrderProductConnections.Queries.GetProductsListbyOrder
{
    public class GetProductListOrderQuery : IRequest<GetProductListOrderVm>
    {
        public long OrderId { get; set; }
    }
}
