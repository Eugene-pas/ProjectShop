using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Commands_and_Queries.Customers
{
    public class CustomerExistTask
    {
        private readonly IDataBaseContext _dbContext;
        public CustomerExistTask(IDataBaseContext dbContext) =>
            _dbContext = dbContext;

        public async Task<bool> Exist(long customerId, CancellationToken cancellationToken)
        {
            return await _dbContext.Customer
                .AnyAsync(x => x.Id == customerId);
        }
    }
}
