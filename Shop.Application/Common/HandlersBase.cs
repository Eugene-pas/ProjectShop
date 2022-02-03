using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Customers.Commands
{
    public abstract class HandlersBase
    {
        protected readonly IDataBaseContext _dbContext;
        public HandlersBase(IDataBaseContext dbContext) =>
            _dbContext = dbContext;
    }
}
