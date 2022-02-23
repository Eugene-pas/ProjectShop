using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Commands.Baskets;
using Shop.Application.Common;
using Shop.Application.Exceptions;
using Shop.Application.Interfaces;
using Shop.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Commands.BasketItems.Commands.UpdateBasketItem
{
    public class UpdateBasketItemCommandHandler
        :HandlersBase, IRequestHandler<UpdateBasketItemCommand, BasketItemVm>
    {
        public UpdateBasketItemCommandHandler(IDataBaseContext dbContext, IMapper mapper)
            : base(dbContext, mapper) { }
        public async Task<BasketItemVm> Handle(UpdateBasketItemCommand request, CancellationToken cancellationToken)
        {
            var basketItem = await _dbContext.BasketItem
                .Include(x => x.Product).ThenInclude(x => x.ProductImage)
                .FirstOrDefaultAsync(basketItem=>
                basketItem.Id == request.Id, cancellationToken);

            _ = basketItem ?? throw new NotFoundException(nameof(BasketItem), basketItem.Id);

            if (basketItem.Count + request.Count <= _dbContext.Product.Find(basketItem.Product.Id).OnStorageCount)
                basketItem.Count = request.Count;
            else if (request.Count > _dbContext.Product.Find(basketItem.Product.Id).OnStorageCount)
            {
                throw new NotEnoughProductsOnStorageException(_dbContext.Product.Find(basketItem.Product.Id).Name,
                    _dbContext.Product.Find(basketItem.Product.Id).OnStorageCount);
            }

            await _dbContext.SaveChangesAsync(cancellationToken);

            return _mapper.Map<BasketItemVm>(basketItem);

        }
    }
}
