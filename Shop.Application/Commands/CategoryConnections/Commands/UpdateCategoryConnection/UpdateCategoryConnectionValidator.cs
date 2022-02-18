using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Commands.CategoryConnections.Commands.UpdateCategoryConnection
{
    public class UpdateCategoryConnectionValidator
        : AbstractValidator<UpdateCategoryConnectionCommand>
    {
        private readonly IDataBaseContext _dbContext;

        public UpdateCategoryConnectionValidator(IDataBaseContext dbContext)
        {
            _dbContext = dbContext;
            RuleFor(updateCategory =>
                    updateCategory.Id).NotEmpty().NotEqual(0)
                .WithMessage("The Id value must not equal to 0")
                .MustAsync(CategoryConnectionExist)
                .WithMessage("The Id ParentId doesn't exist.");
            RuleFor(updateConnection =>
                    updateConnection.ParentId).NotEmpty().NotEqual(0)
                .WithMessage("The ParentId value must not equal to 0")
                .MustAsync(CategoryExist)
                .WithMessage("The specified ParentId doesn't exist.");
            RuleFor(updateConnection =>
                    updateConnection.ChildId).NotEmpty().NotEqual(0)
                .WithMessage("The ChildId value must not equal to 0")
                .MustAsync(CategoryExist)
                .WithMessage("The specified ChildId doesn't exist.");
        }
        public async Task<bool> CategoryExist(long Id, CancellationToken cancellationToken)
        {
            return await _dbContext.Category
                .AnyAsync(o => o.Id == Id);
        }
        public async Task<bool> CategoryConnectionExist(long Id, CancellationToken cancellationToken)
        {
            return await _dbContext.CategoryConnection
                .AnyAsync(o => o.Id == Id);
        }

    }
}
