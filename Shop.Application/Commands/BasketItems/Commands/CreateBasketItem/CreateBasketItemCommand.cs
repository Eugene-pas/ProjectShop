using MediatR;
using Shop.Application.Commands.Baskets;

namespace Shop.Application.Commands.BasketItems.Commands.CreateBasketItem
{
    public class CreateBasketItemCommand : IRequest<BasketItemVm>
    {
        
        public long ProductId { get; set; }
        public long BasketId { get; set; }
        public int Count { get; set; }
    }
}
