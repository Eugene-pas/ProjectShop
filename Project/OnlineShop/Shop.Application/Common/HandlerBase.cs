using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Customers.Commands
{
    public abstract class HandlerBase
    {
        public readonly IDataBaseContext _dbContext;
        public HandlerBase(IDataBaseContext dbContext) =>
            _dbContext = dbContext;
    }
}
