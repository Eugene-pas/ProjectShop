using MediatR;

namespace Shop.Application.Commands.Baskets.Commands.CreateBasket
{
    public class CreateBasketCommand : IRequest<BasketVm>
    {
        public long CustomerId { get; set; }
    }
}
