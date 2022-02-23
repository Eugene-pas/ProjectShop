using MediatR;

namespace Shop.Application.Commands.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest<ProductVm>
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public long CategoryId { get; set; }

        public string Description { get; set; }

        public int? OnStorageCount { get; set; }
        
        public long SellerId { get; set; }
    }
}
