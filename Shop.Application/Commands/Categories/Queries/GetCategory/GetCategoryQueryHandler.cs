using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Categories.Commands.Queries.GetCategory
{
    public class GetCategoryQueryHandler
        : IRequestHandler<GetCategoryQuery, CategoryVm>
    {
        private readonly IDataBaseContext _dbContext;
        private readonly IMapper _mapper;

        public GetCategoryQueryHandler(IDataBaseContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<CategoryVm> Handle(GetCategoryQuery request,
            CancellationToken cancellationToken)
        {
            var categoriesQuery = await _dbContext.Category
                .ProjectTo<CategoryVm>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return categoriesQuery.FirstOrDefault(x => x.Id == request.Id);
        }
    }
}
