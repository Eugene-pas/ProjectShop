using MediatR;

namespace Shop.Application.Commands.Products.Queries.GetProductsList
{
    public class GetProductsListQuery : IRequest<ProductsListVm>
    { }
}
