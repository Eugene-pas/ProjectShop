using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Interfaces;

namespace Shop.Application.Commands.Products
{
    internal class ProductExistTask
    {
        private readonly IDataBaseContext _dbContext;
        public ProductExistTask(IDataBaseContext dbContext) =>
            _dbContext = dbContext;

        public async Task<bool> Exist(long productId, CancellationToken cancellationToken)
        {
            return await _dbContext.Product
                .AnyAsync(x => x.Id == productId);
        }
    }
}
