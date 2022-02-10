using MediatR;
using Shop.Application.Commands_and_Queries.Products;

namespace Shop.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest<ProductVm>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int? OnStorageCount { get; set; }
        public double? Rating { get; set; }

    }
}
