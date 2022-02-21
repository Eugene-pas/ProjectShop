using MediatR;
using Shop.Domain.Entities;

namespace Shop.Application.Commands.ProductImages.Commands.UpdateProductImage
{
    public class UpdateProductImageCommand
        : IRequest
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public string Image { get; set; }
        public int? SortOrder { get; set; }       

        public virtual Product Product { get; set; }

    }
}
