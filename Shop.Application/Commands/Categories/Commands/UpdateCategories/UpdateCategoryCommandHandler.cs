using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Commands.Categories.Queries.GetCategory;
using Shop.Application.Common;
using Shop.Application.Exceptions;
using Shop.Application.Interfaces;
using Shop.Domain.Entities;

namespace Shop.Application.Commands.Categories.Commands.UpdateCategories
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
            category.Id == request.CategoryId, cancellationToken);

            _ = category ?? throw new NotFoundException(nameof(Category), category.Id);

            category.Name = request.Name;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return _mapper.Map<CategoryVm>(category);
        }
    }
}
