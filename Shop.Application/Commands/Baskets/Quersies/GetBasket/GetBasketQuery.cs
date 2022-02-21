using MediatR;

namespace Shop.Application.Commands.Baskets.Quersies.GetBasket
{
    public class GetBasketQuery : IRequest<BasketVm>
    {
        public long Id { get; set; }
    }
}
