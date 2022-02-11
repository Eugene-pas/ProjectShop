using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Categories.Queries.GetCatagoryList;
using Shop.Application.Exceptions;
using Shop.Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Categories.Commands.Queries.GetCategory
{
    public class GetCategoryQueryHandler
        : IRequestHandler<GetCategoryQuery, CategoriesListVm>
    {
        private readonly IDataBaseContext _dbContext;
        private readonly IMapper _mapper;

        public GetCategoryQueryHandler(IDataBaseContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<CategoriesListVm> Handle(GetCategoryQuery request,
            CancellationToken cancellationToken)
        {
            //var category = await _dbContext.Category
            //.Include(x => x.ParentCategory.ParentCategory.ParentCategory
            //.ParentCategory.ParentCategory.ParentCategory.ParentCategory
            //.ParentCategory.ParentCategory.ParentCategory.ParentCategory)              
            //.FirstOrDefaultAsync(category =>
            //category.Id == request.Id, cancellationToken);

            var categoriesQuery = await _dbContext.Category.Where(x => x.Id == request.Id)
                .ProjectTo<CategoryVm>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
           
            if (categoriesQuery.Count == 0)
            {
                throw new NotFoundException(nameof(Category), request.Id);
            }

            return new CategoriesListVm { Categories = categoriesQuery };

            //return _mapper.Map<CategoryVm>(category);
            //return category;
        }
    }
}
