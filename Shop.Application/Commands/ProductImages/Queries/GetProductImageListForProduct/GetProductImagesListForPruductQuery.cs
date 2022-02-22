using MediatR;

namespace Shop.Application.Commands.ProductImages.Queries.GetProductImageListForProduct
{
    public class GetProductImagesListForPruductQuery
        : IRequest<ProductImageForProductVm>
    {
        public long ProductId { get; set; }
    }
}
