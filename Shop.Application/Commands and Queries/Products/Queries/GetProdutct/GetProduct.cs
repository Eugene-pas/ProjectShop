using MediatR;

namespace Shop.Application.Products.Queries.GetProduct
{
    public class GetProduct : IRequest<ProductVm>
    {
        public long Id { get; set; }
    }
}
