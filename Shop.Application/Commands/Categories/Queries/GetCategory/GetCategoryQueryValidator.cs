using FluentValidation;
using Shop.Application.Categories.Commands.Queries.GetCategory;
using Shop.Domain.Entities;

namespace Shop.Application.Commands_and_Queries.Categories.Queries.GetCategory
{
    public class GetCategoryQueryValidator
        : AbstractValidator<GetCategoryQuery>
    {
        private CategoryExistTask existTask;
        public GetCategoryQueryValidator(IDataBaseContext dbContext)
        {
            existTask = new CategoryExistTask(dbContext);

            RuleFor(getCategoryrQueryValidator =>
            getCategoryrQueryValidator.Id)
                .NotEmpty().WithMessage("ID is required.")
                .NotNull().WithMessage("ID can not be aqueal null.")
                .NotEqual(0).WithMessage("There is no field with this ID")
                .MustAsync(existTask.Exist).WithMessage("The specified customerId doesn't exist");
        }
    }
}
