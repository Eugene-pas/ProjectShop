﻿using FluentValidation;
using Shop.Application.Interfaces;

namespace Shop.Application.Commands.Categories.Commands.CreateCategories
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
        }
    }
}
