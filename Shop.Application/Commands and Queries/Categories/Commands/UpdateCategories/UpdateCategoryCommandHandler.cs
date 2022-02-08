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

namespace Shop.Application.Categories.Commands.UpdateCategories
{
    public class UpdateCategoryCommandHandler
        : IRequestHandler<UpdateCategoryCommand>
    {
        private readonly IDataBaseContext _dbContext;
        public UpdateCategoryCommandHandler(IDataBaseContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _dbContext.Category
                .FirstOrDefaultAsync(category =>
            category.Id == request.Id,cancellationToken);

            _ = category ?? throw new NotFoundException(nameof(Category), category.Id);

            category.Name = request.Name;
            category.parentId = request.parentId;

        await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
