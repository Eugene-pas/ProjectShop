using MediatR;

namespace Shop.Application.Commands.Products.Queries.GetProduct
{
    public class GetProductQuery : IRequest<ProductVm>
    {
        public long Id { get; set; }
    }
}
