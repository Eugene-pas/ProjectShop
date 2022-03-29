using MediatR;

namespace Shop.Application.Commands.OrderProducts.Queries.GetOrdersProductList
{
    public class GetOrderProductListQuery
        : IRequest<OrderProductListVm>
    {
    }
}
