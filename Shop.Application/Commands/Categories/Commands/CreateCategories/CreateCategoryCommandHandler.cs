using AutoMapper;
using MediatR;
using Shop.Application.Categories.Commands.Queries.GetCategory;
using Shop.Application.Common;
using Shop.Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Shop.Application.Categories.Commands.CreateCategories
{
    public class CreateCategoryCommandHandler
        : HandlersBase, IRequestHandler<CreateCategoryCommand, CategoryVm>
    {
        public CreateCategoryCommandHandler(IDataBaseContext dbContext, IMapper mapper)
            : base(dbContext, mapper) { }

        public async Task<CategoryVm> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {

            var category = new Category
            {
                Name = request.Name
            };
            if (!_dbContext.Category.Any(x => x.Name == request.Name))
            {
                await _dbContext.Category.AddAsync(category, cancellationToken);
                await _dbContext.SaveChangesAsync(cancellationToken);
                
            }
            var categoryVm = _mapper.Map<CategoryVm>(category);
            if (request.ParentId != 0)
            {

                var categoryConnection = new CategoryConnection
                {
                    ParentId = request.ParentId,
                    Category = category,
                    
                };
                await _dbContext.CategoryConnection.AddAsync(categoryConnection, cancellationToken);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }





            return _mapper.Map<CategoryVm>(category);
        }
    }
}
