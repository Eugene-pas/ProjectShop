using MediatR;
using Shop.Application.Products.Queries.GetProductsList;

namespace Shop.Application.Commands_and_Queries.Products.Queries.GetProductsListByPrice
{
    public class GetProductsListByPriceQuery : IRequest<ProductsListVm>
    {
        public long Id { get; set; }
    }
}
