using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Shop.Application.Commands.Categories.Queries.GetCategory;
using Shop.Application.Common;
using Shop.Application.Exceptions;
using Shop.Application.Interfaces;
using Shop.Domain.Entities;

namespace Shop.Application.Commands.Categories.Commands.DeleteCategories
{
    public class DeleteCategoryCommandHandler
        : HandlersBase, IRequestHandler<DeleteCategoryCommand, CategoryVm>
    {
        public DeleteCategoryCommandHandler(IDataBaseContext dbContext, IMapper mapper)
            : base(dbContext, mapper) { }

        public async Task<CategoryVm> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _dbContext.Category
                .FindAsync(new object[] { request.Id }, cancellationToken);

            _ = category ?? throw new NotFoundException(nameof(Category), category.Id);

            _dbContext.Category.Remove(category);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return _mapper.Map<CategoryVm>(category);
        }
    }
}
