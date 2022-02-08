using MediatR;
using Shop.Application.Exceptions;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Categories.Commands.DeleteCategories
{
    public class DeleteCategoryCommandHandler
        : IRequestHandler<DeleteCategoryCommand>
    {
        private readonly IDataBaseContext _dbContext;
        public DeleteCategoryCommandHandler(IDataBaseContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _dbContext.Category
                .FindAsync(new object[] { request.Id }, cancellationToken);

            _ = category ?? throw new NotFoundException(nameof(Category), category.Id);
            _dbContext.Category.Remove(category);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
