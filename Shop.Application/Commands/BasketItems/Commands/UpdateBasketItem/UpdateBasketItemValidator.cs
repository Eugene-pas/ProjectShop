using FluentValidation;
using Shop.Application.Interfaces;

namespace Shop.Application.Commands.BasketItems.Commands.UpdateBasketItem
{
    public class UpdateBasketItemValidator
        : AbstractValidator<UpdateBasketItemCommand>
    {
        private readonly BasketItemExistTask existTask;
        public UpdateBasketItemValidator(IDataBaseContext dbContext)
        {
            existTask = new BasketItemExistTask(dbContext);

            RuleFor(updateBasketCommandValidator =>
            updateBasketCommandValidator.Id)
            .NotEmpty().NotNull().WithMessage("Basket Id is required.")
            .NotEqual(0).WithMessage("There is no basket with this ID")
            .MustAsync(existTask.ExistBasket)
            .WithMessage("The specified basket doesn't exist");

            RuleFor(updateBasketCommandValidator =>
            updateBasketCommandValidator.Count)
            .NotEmpty().NotNull().WithMessage("Product count is required.")
            .NotEqual(0).WithMessage("Count can not be equal 0");
        }
    }
}
