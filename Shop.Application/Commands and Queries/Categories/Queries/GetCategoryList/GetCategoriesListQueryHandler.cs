using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Categories.Commands.Queries.GetCategory;
using Shop.Application.Categories.Queries.GetCatagoryList;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Categories.Queries.GetCatagoryList
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
