using MediatR;
using Shop.Application.Commands_and_Queries.Products;

namespace Shop.Application.Products.Queries.GetProduct
{
    public class GetProductQuery : IRequest<ProductVm>
    {
        public long Id { get; set; }
    }
}
