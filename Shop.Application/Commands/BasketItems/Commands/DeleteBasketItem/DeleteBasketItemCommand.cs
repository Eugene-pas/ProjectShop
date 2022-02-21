using MediatR;
using Shop.Application.Commands.Baskets;

namespace Shop.Application.Commands.BasketItems.Commands.DeleteBasketItem
{
    public class DeleteBasketItemCommand : IRequest<BasketItemVm>
    {
        public long Id { get; set; }
    }
}
