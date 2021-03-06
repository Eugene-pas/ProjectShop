using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Shop.Domain.Entities;
using Shop.Application.Categories.Commands.Queries.GetCategory;

namespace Shop.Application.Categories.Queries.GetCategoryList
{
    public class GetCategoriesListQueryHandler
        : IRequestHandler<GetCategoriesListQuery, CategoriesListVm>
    {
        private readonly IDataBaseContext _dbContext;
        private readonly IMapper _mapper;

        public GetCategoriesListQueryHandler(IDataBaseContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);
        public async Task<CategoriesListVm> Handle(GetCategoriesListQuery request, CancellationToken cancellationToken)
        {
            var categoriesQuery = await _dbContext.Category
                .ProjectTo<CategoryVm>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new CategoriesListVm { Categories = categoriesQuery };
        }
    }
}
