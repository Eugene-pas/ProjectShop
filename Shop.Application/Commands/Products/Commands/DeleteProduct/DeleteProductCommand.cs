using MediatR;

namespace Shop.Application.Commands.Products.Commands.DeleteProduct
{
    public class DeleteProductCommand : IRequest<ProductVm>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int? OnStorageCount { get; set; }
        public double? Rating { get; set; }
    }
}
