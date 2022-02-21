using Microsoft.EntityFrameworkCore;
using Shop.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;


namespace Shop.Application.Commands.BasketItems
{
    public class BasketItemExistTask
    {
        private readonly IDataBaseContext _dbContext;
        public BasketItemExistTask(IDataBaseContext dbContext) =>
            _dbContext = dbContext;

        public async Task<bool> ExistBasketItem(long basketItemId, CancellationToken cancellationToken)
        {
            return await _dbContext.BasketItem
                .AnyAsync(x => x.Id == basketItemId);
        }
        public async Task<bool> ExistBasket(long basketId, CancellationToken cancellationToken)
        {
            return await _dbContext.Basket
                .AnyAsync(x => x.Id == basketId);
        }
        public async Task<bool> ExistProduct(long producId, CancellationToken cancellationToken)
        {
            return await _dbContext.Product
                .AnyAsync(x => x.Id == producId);
        }
    }
}
