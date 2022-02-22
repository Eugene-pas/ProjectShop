using AutoMapper;
using MediatR;
using Shop.Application.Common;
using Shop.Application.Exceptions;
using Shop.Application.Interfaces;
using Shop.Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Commands.Baskets.Commands.DeleteBasket
{
    public class DeleteBasketCommandHandler
        : HandlersBase, IRequestHandler<DeleteBasketCommand, BasketVm>
    {
        public DeleteBasketCommandHandler(IDataBaseContext dbContext, IMapper mapper)
            : base(dbContext, mapper) { }
        public async Task<BasketVm> Handle(DeleteBasketCommand request, CancellationToken cancellationToken)
        {
            var basket = await _dbContext.Basket
                .FindAsync(new object[] { request.Id }, cancellationToken);

            _ = basket ?? throw new NotFoundException(nameof(Basket), basket.Id);

            var basketItem = _dbContext.BasketItem
                .Where(x => x.Basket.Id == request.Id);

            _dbContext.BasketItem.RemoveRange(basketItem);
            _dbContext.Basket.Remove(basket);

            await _dbContext.SaveChangesAsync(cancellationToken);
            return _mapper.Map<BasketVm>(basket);
        }
    }
}
