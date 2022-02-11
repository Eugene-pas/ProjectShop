using Shop.Domain.Entities;
using AutoMapper;

namespace Shop.Application.Common
{
    public abstract class HandlersBase
    {
        protected readonly IDataBaseContext _dbContext;
        protected readonly IMapper _mapper;
        public HandlersBase(IDataBaseContext dbContext, IMapper mapper) =>
              (_dbContext, _mapper) = (dbContext, mapper);
    }
}
