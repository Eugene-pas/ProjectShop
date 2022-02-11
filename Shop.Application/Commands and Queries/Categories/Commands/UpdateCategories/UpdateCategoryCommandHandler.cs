using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Shop.Application.Categories.Commands.Queries.GetCategory;
using Shop.Application.Exceptions;
using Shop.Application.Common;
using Shop.Domain.Entities;

namespace Shop.Application.Categories.Commands.UpdateCategories
{
    public class UpdateCategoryCommandHandler
        : HandlersBase, IRequestHandler<UpdateCategoryCommand, CategoryVm>
    {
        public UpdateCategoryCommandHandler(IDataBaseContext dbContext, IMapper mapper)
            : base(dbContext, mapper) { }

        public async Task<CategoryVm> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _dbContext.Category
                .FirstOrDefaultAsync(category =>
            category.Id == request.Id, cancellationToken);

            _ = category ?? throw new NotFoundException(nameof(Category), category.Id);

            category.Name = request.Name;
            category.ParentCategory = _dbContext.Category.Find(request.ParentId);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return _mapper.Map<CategoryVm>(category);
        }
    }
}
