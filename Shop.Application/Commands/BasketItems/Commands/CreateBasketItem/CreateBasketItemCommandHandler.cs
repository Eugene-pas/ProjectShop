using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Commands.Baskets;
using Shop.Application.Common;
using Shop.Application.Exceptions;
using Shop.Application.Interfaces;
using Shop.Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Commands.BasketItems.Commands.CreateBasketItem
{
    internal class CreateBasketItemCommandHandler
        : HandlersBase, IRequestHandler<CreateBasketItemCommand, BasketItemVm>
    {
        public CreateBasketItemCommandHandler(IDataBaseContext dbContext, IMapper mapper)
            : base(dbContext, mapper) { }
        public async Task<BasketItemVm> Handle(CreateBasketItemCommand request,
            CancellationToken cancellationToken)
        {
            var basketItem = new BasketItem();

            if (!_dbContext.BasketItem.Any(x => x.Basket.Id == request.BasketId && x.Product.Id == request.ProductId))
            {
                if (request.Count <= _dbContext.Product.Find(request.ProductId).OnStorageCount)
                {
                    basketItem = new BasketItem
                    {
                        Product = _dbContext.Product.Include(x => x.ProductImage).First(x => x.Id == request.ProductId),
                        Basket = _dbContext.Basket.Find(request.BasketId),
                        Count = request.Count,
                    };
                    await _dbContext.BasketItem.AddAsync(basketItem, cancellationToken);
                }
                else if (request.Count > _dbContext.Product.Find(request.ProductId).OnStorageCount)
                {
                    throw new NotEnoughProductsOnStorageException(_dbContext.Product.Find(request.ProductId).Name,
                        _dbContext.Product.Find(request.ProductId).OnStorageCount);
                }
            }

            else
            {
                basketItem = _dbContext.BasketItem
                    .Include(x => x.Product).ThenInclude(x => x.ProductImage)
                    .First(x => x.Basket.Id == request.BasketId && x.Product.Id == request.ProductId);

                if (basketItem.Count + request.Count <= _dbContext.Product.Find(request.ProductId).OnStorageCount)
                    basketItem.Count += request.Count;
                
                else
                {
                    throw new NotEnoughProductsOnStorageException(_dbContext.Product.Find(request.ProductId).Name,
                        _dbContext.Product.Find(request.ProductId).OnStorageCount);
                }
            }


            await _dbContext.SaveChangesAsync(cancellationToken);
            return _mapper.Map<BasketItemVm>(basketItem);
        }
    }
}
