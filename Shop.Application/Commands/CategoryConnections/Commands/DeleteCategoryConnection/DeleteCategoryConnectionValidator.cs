using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using Shop.Application.Interfaces;

namespace Shop.Application.Commands.CategoryConnections.Commands.DeleteCategoryConnection
{
    public class DeleteCategoryConnectionValidator
        : AbstractValidator<DeleteCategoryConnectionCommand>
    {
        private readonly IDataBaseContext _dbContext;

        public DeleteCategoryConnectionValidator(IDataBaseContext dbContext)
        {
            _dbContext = dbContext;

            RuleFor(deleteCategory =>
                    deleteCategory.Id).NotEmpty().NotEqual(0)
                .WithMessage("The ParentId value must not equal to 0")
                .MustAsync(Exist)
                .WithMessage("The specified ParentId doesn't exist.");
        }
        public async Task<bool> Exist(long Id, CancellationToken cancellationToken)
        {
            return await _dbContext.CategoryConnection
                .AnyAsync(o => o.Id == Id);
        }

    }
}
