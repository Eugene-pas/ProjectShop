using FluentValidation;
using Shop.Application.Categories.Commands.DeleteCategories;
using Shop.Domain.Entities;

namespace Shop.Application.Commands_and_Queries.Categories.Commands.DeleteCategories
{
    public class DeleteCategoryCommandValidator
        : AbstractValidator<DeleteCategoryCommand>
    {
        private readonly CategoryExistTask existTask;
        public DeleteCategoryCommandValidator(IDataBaseContext dbContext)
        {
            existTask = new CategoryExistTask(dbContext);

            RuleFor(deleteCategoryCommandValidator =>
            deleteCategoryCommandValidator.Id)
                .NotEmpty().WithMessage("ID is required.")
                .NotNull().WithMessage("ID can not be equeal null.")
                .GreaterThan(0).WithMessage("ID must be greater than zero.")
                .MustAsync(existTask.Exist).WithMessage("There is no field with this ID.")
                .WithMessage("The specified customerId doesn't exist.");
        }
    }
}
