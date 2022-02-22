using MediatR;

namespace Shop.Application.Commands.ProductImages.Queries.GetProductImagesList
{
    public class GetProductImagesListQuery
        : IRequest<ProductImageVm>
    {             
    }
}
