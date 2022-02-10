using MediatR;

namespace Shop.Application.Commands_and_Queries.ProductImages.Queries.GetProductImageListForProduct
{
    public class GetProductImagesListForPruductQuery
        : IRequest<ProductImageForProductVm>
    {
        public long ProductId { get; set; }
    }
}
