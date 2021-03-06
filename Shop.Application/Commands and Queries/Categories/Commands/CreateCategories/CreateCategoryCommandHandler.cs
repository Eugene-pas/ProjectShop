using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Shop.Application.Categories.Commands.Queries.GetCategory;
using Shop.Application.Common;
using Shop.Domain.Entities;

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
                Name = request.Name,
                ParentCategory = _dbContext.Category.Find(request.ParentId)
            };

            await _dbContext.Category.AddAsync(category, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return _mapper.Map<CategoryVm>(category);
        }
    }
}
