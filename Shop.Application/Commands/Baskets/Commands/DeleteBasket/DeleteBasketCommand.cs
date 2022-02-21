using MediatR;

namespace Shop.Application.Commands.Baskets.Commands.DeleteBasket
{
    public class DeleteBasketCommand : IRequest<BasketVm>
    {
        public long Id { get; set; }
    }
}
