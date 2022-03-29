using MediatR;

namespace Shop.Application.Commands.OrderProducts.Queries.GetProductsListbyOrder
{
    public class GetProductListOrderQuery : IRequest<ProductListByOrderVm>
    {
        public long OrderId { get; set; }
    }
}
