using FluentValidation;
using Shop.Application.Categories.Commands.CreateCategories;
using Shop.Domain.Entities;

namespace Shop.Application.Commands_and_Queries.Categories.Commands.CreateCategories
{
    public class CreateCategoryCommandValidator
        : AbstractValidator<CreateCategoryCommand>
    {
        private CategoryExistTask existTask;
        public CreateCategoryCommandValidator(IDataBaseContext dbContext)
        {
            existTask = new CategoryExistTask(dbContext);

            RuleFor(createCategoryCammandValidator =>
            createCategoryCammandValidator.Name)
                .NotEmpty().WithMessage("Name is required.")
                .NotNull().WithMessage("Name can not be aqueal null.");

            //RuleFor(createCategoryCammandValidator =>
            //createCategoryCammandValidator.ParentId)
            //    .Empty()
            //    .GreaterThan(0).WithMessage("Parent ID must be greater than zero.")
            //    .MustAsync(existTask.Exist).WithMessage("There is no field with this Parent ID.");
        }
    }
}
