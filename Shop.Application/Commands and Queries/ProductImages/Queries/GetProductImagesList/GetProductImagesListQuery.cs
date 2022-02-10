using MediatR;
using Shop.Application.Commands_and_Queries.ProductImages.Queries;

namespace Shop.Application.ProductImages.Queries.GetProducImagesList
{
    public class GetProductImagesListQuery
        : IRequest<ProductImageVm>
    {             
    }
}
