using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Commands.CategoryConnections.Commands.DeleteCategoryConnection;
using Shop.Domain.Entities;

namespace Shop.Application.Commands.CategoryConnections.Queries.GetSubcategoriesList
{
    public class GetSubcategoriesListValidator
        : AbstractValidator<GetSubcategoriesListQuery>
    {
        private readonly IDataBaseContext _dbContext;

        public GetSubcategoriesListValidator(IDataBaseContext dbContext)
        {
            _dbContext = dbContext;

            RuleFor(deleteCategory =>
                    deleteCategory.ParentId).NotEmpty().NotEqual(0)
                .WithMessage("The ParentId value must not equal to 0")
                .MustAsync(Exist)
                .WithMessage("The specified ParentId doesn't exist.");
        }
        public async Task<bool> Exist(long Id, CancellationToken cancellationToken)
        {
            return await _dbContext.Category
                .AnyAsync(o => o.Id == Id);
        }

    }
}
