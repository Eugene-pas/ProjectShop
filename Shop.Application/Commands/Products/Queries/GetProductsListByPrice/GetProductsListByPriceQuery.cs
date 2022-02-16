using MediatR;
using Shop.Application.Products.Queries.GetProductsList;

namespace Shop.Application.Commands.Products.Queries.GetProductsListByPrice
{
    public class GetProductsListByPriceQuery : IRequest<ProductsListVm>
    {
        public long CategoryId { get; set; }
    }
}
