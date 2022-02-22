using AutoMapper;
using MediatR;
using Shop.Application.Commands.Baskets;
using Shop.Application.Common;
using Shop.Application.Exceptions;
using Shop.Application.Interfaces;
using Shop.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Commands.BasketItems.Commands.DeleteBasketItem
{
    public class DeleteBasketItemCommandHandler
        : HandlersBase, IRequestHandler<DeleteBasketItemCommand, BasketItemVm>
    {
        public DeleteBasketItemCommandHandler(IDataBaseContext dbContext, IMapper mapper)
            : base(dbContext, mapper) { }
        public async Task<BasketItemVm> Handle(DeleteBasketItemCommand request, CancellationToken cancellationToken)
        {
            var basketItem = await _dbContext.BasketItem
                .FindAsync(new object[] { request.Id }, cancellationToken);

            _ = basketItem ?? throw new NotFoundException(nameof(BasketItem), basketItem.Id);

            _dbContext.BasketItem.Remove(basketItem);

            await _dbContext.SaveChangesAsync(cancellationToken);
            return _mapper.Map<BasketItemVm>(basketItem);
        }
    }
}
