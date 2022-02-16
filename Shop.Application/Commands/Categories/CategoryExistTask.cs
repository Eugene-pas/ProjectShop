using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Commands_and_Queries.Categories
{
    public class CategoryExistTask
    {
        private readonly IDataBaseContext _dbContext;
        public CategoryExistTask(IDataBaseContext dbContext) =>
            _dbContext = dbContext;

        public async Task<bool> Exist(long customerId, CancellationToken cancellationToken)
        {
            return await _dbContext.Category
                .AnyAsync(x => x.Id == customerId);
        }
    }
}
