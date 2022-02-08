using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Exceptions;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            var category = await _dbContext.Category
                .FirstOrDefaultAsync(category =>
                category.Id == request.Id, cancellationToken);

            _ = category ?? throw new NotFoundException(nameof(Category), request.Id);


            return _mapper.Map<CategoryVm>(category);
        }
    }
}
