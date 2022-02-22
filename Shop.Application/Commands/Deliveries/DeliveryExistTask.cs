using Microsoft.EntityFrameworkCore;
using Shop.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Commands.Deliveries
{
    internal class DeliveryExistTask
    {
        private readonly IDataBaseContext _dbContext;
        public DeliveryExistTask(IDataBaseContext dbContext) =>
            _dbContext = dbContext;

        public async Task<bool> Exist(long deliveryId, CancellationToken cancellationToken)
        {
            return await _dbContext.Delivery
                .AnyAsync(x => x.Id == deliveryId, cancellationToken);
        }
    }
}
