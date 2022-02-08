using MediatR;
using Shop.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Shop.Application.Categories.Commands.CreateCategories
{
    public class CreateCategoryCommandHandler
        : IRequestHandler<CreateCategoryCommand, long>
    {
        private readonly IDataBaseContext _dbContext;
        public CreateCategoryCommandHandler(IDataBaseContext dbContext) =>
            _dbContext = dbContext;

        public async Task<long> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {

            var category = new Category 
            {                
                Name = request.Name,
                ParentCategory = _dbContext.Category.Find(request.ParentId)
            };
            await _dbContext.Category.AddAsync(category, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return category.Id;
        }
    }
}
