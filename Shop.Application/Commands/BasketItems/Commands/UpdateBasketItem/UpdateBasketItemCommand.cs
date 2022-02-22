using MediatR;
using Shop.Application.Commands.Baskets;
using Shop.Domain.Entities;

namespace Shop.Application.Commands.BasketItems.Commands.UpdateBasketItem
{
    public class UpdateBasketItemCommand : IRequest<BasketItemVm>
    {
        public long Id { get; set; }
        public int Count { get; set; }
    }
}
