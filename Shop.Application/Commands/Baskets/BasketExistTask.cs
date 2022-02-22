using Microsoft.EntityFrameworkCore;
using Shop.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Commands.Baskets
{
    public class BasketExistTask
    {
        private readonly IDataBaseContext _dbContext;
        public BasketExistTask(IDataBaseContext dbContext) =>
            _dbContext = dbContext;

        public async Task<bool> Exist(long basketId, CancellationToken cancellationToken)
        {
            return await _dbContext.Basket
                .AnyAsync(x => x.Id == basketId);
        }
    }
}
