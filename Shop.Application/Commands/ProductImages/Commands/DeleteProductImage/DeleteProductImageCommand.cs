using MediatR;

namespace Shop.Application.Commands.ProductImages.Commands.DeleteProductImage
{
    public class DeleteProductImageCommand
        : IRequest<Unit>
    {
        public long Id { get; set; }
    }
}
