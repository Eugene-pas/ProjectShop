using FluentValidation;
using Shop.Application.Categories.Commands.UpdateCategories;
using Shop.Domain.Entities;

namespace Shop.Application.Commands_and_Queries.Categories.Commands.UpdateCategories
{
    public class UpdateCategoryCommandValidator
        : AbstractValidator<UpdateCategoryCommand>
    {
        private readonly CategoryExistTask existTask;
        public UpdateCategoryCommandValidator(IDataBaseContext dbContext)
        {
            existTask = new CategoryExistTask(dbContext);

            RuleFor(updateCategoryCommandValidator =>
            updateCategoryCommandValidator.Id)
                .NotEmpty().WithMessage("ID is required.")
                .NotNull().WithMessage("ID can not be equeal null.")
                .GreaterThan(0).WithMessage("ID must be greater than zero.")
                .MustAsync(existTask.Exist).WithMessage("There is no field with this ID.")
                .WithMessage("The specified customerId doesn't exist.");

            RuleFor(updateCategoryCommandValidator =>
            updateCategoryCommandValidator.Name)
                .NotEmpty().WithMessage("Name is required.")
                .NotNull().WithMessage("Name can not be aqueal null.");

            //RuleFor(updateCategoryCommandValidator =>
            //updateCategoryCommandValidator.ParentId)
            //    .Empty()
            //    .GreaterThan(0).WithMessage("Parent ID must be greater than zero.")
            //    .MustAsync(existTask.Exist).WithMessage("There is no field with this Parent ID.");
        }
    }
}
