using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using Shop.Application.Interfaces;

namespace Shop.Application.Commands.Products.Queries.GetProductsListByCategory
{
    public class GetProductsListByCategoryValidator
        : AbstractValidator<GetProductsListByCategoryQuery>
    {
        private readonly IDataBaseContext _dbContext;

        public GetProductsListByCategoryValidator(IDataBaseContext dbContext)
        {
            _dbContext = dbContext;

            RuleFor(deleteCategory =>
                    deleteCategory.CategoryId).NotEmpty().NotEqual(0)
                .WithMessage("The CategoryId value must not equal to 0")
                .MustAsync(Exist)
                .WithMessage("The specified CategoryId doesn't exist.");
        }
        public async Task<bool> Exist(long Id, CancellationToken cancellationToken)
        {
            return await _dbContext.Category
                .AnyAsync(o => o.Id == Id);
        }

    }
}
