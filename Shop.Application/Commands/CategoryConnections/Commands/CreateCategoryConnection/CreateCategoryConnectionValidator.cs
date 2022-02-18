using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Commands.CategoryConnections.Commands.CreateCategoryConnection
{
    public class CreateCategoryConnectionValidator
        : AbstractValidator<CreateCategoryConnectionCommand>
    {
        private readonly IDataBaseContext _dbContext;

        public CreateCategoryConnectionValidator(IDataBaseContext dbContext)
        {
            _dbContext = dbContext;

            RuleFor(createConnection =>
                    createConnection.ParentId).NotEmpty().NotEqual(0)
                .WithMessage("The ParentId value must not equal to 0")
                .MustAsync(Exist)
                .WithMessage("The specified ParentId doesn't exist.");
            RuleFor(createConnection =>
                    createConnection.ChildId).NotEmpty().NotEqual(0)
                .WithMessage("The ChildId value must not equal to 0")
                .MustAsync(Exist)
                .WithMessage("The specified ChildId doesn't exist.");
        }
        public async Task<bool> Exist(long Id, CancellationToken cancellationToken)
        {
            return await _dbContext.Category
                .AnyAsync(o => o.Id == Id);
        }
        
    }
}
