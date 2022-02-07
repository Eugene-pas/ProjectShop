using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Commands_and_Queries.Products
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
